using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace tiktactoe
{
    enum sides {  center=0,left,right, up,down};
    enum GameFinish { draw, win, lose};
    public class AI
    {
        public Difficulity difficulity { get; set; }
        private int depth=0;
        private CellE me;
        private CellE him;

        public CellE AISign
        {
            get { return me; }
            set
            {
                if (value == him)
                {
                    him = me;
                    me = value;
                }
            }
        }
        public CellE OpponentSign
        {
            get { return him; }
            set
            {
                if (value == me)
                {
                    me = him;
                    him = value;
                }
            }
        }
        public bool IsThinking { get; private set; } = false;

        public AI(Difficulity d,CellE AI=CellE.o,CellE opponent=CellE.x)
        {
            difficulity = d;
            me = AI;
            him = opponent;
            if (me == him)
                throw new ArgumentException("The AI and the opponent cant be the same sign.");
        }
        /// <summary>
        /// Makes the AI decides the best move for it with the difficulity determines how deep
        /// its thinking should be
        /// </summary>
        /// <param name="gl"></param>
        /// <returns></returns>
        public Position DoTurn(GameLogic gl)
        {
            IsThinking = true;
            Position output;
            if (difficulity == Difficulity.easy)
            { output = Easy(gl); IsThinking = false; return output; }
            if (difficulity == Difficulity.medium)
            { output = Medium(gl); IsThinking = false; return output; }
            if (difficulity == Difficulity.hard)
            { output = Hard(gl); IsThinking = false; return output; }
            /*int empty = gl.board.EmptyCells();
            if (MustPut(gl).row != -1)
                return MustPut(gl);*/
            IsThinking = false;
            return null;
        }


        /// <summary>
        /// picks a random position to write to.
        /// </summary>
        /// <param name="gl"></param>
        /// <returns></returns>
        private Position Easy(GameLogic gl)
        {
            Queue<Cell> empty = new Queue<Cell>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gl.board.board[i, j].player == CellE.empty)
                        empty.Enqueue(new Cell(gl.board.board[i, j]));
                }
            }
            Random rnd = new Random();
            int r = rnd.Next(empty.Count);
            while (r != 0)
            {
                empty.Enqueue(empty.Dequeue());
                r--;
            }
            return new Position(empty.Dequeue().position);
        }
        /// <summary>
        /// avoids immidate loses and take easy opportunities for winning.
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position Medium(GameLogic gl)
        {
            if (EasyWin(gl).row != -1)
                return EasyWin(gl);
            if (MustPut(gl).row != -1)
                return MustPut(gl);
            return Easy(gl);

        }
        /// <summary>
        /// procceding to win and "thinks" about the further game.
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position Hard(GameLogic gl)
        {
            if (gl.GetFreeSpaces() == 0)
                return new Position(-1);
            if (EasyWin(gl).row != -1)
                return EasyWin(gl);
            if (MustPut(gl).row != -1)
                return MustPut(gl);
            if (Tricks(gl).row != -1)
              return Tricks(gl);
            return gl.AllFreeSpaces()[0];
            //return BruteForce(gl, CellE.o);
        }
        /// <summary>
        /// return the positin which x will win if put there or -1,-1 if there's no such position
        /// </summary>
        /// <param name="gl">game logic of the game (will not affect the game)</param>
        /// <returns></returns>
        private Position MustPut(GameLogic gl)
        {
            GameLogic ex = new GameLogic(gl);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (PutHim(ex, new Position(i, j)))
                        if (DoHimWon(ex))
                            return new Position(i, j); 
                        else
                            ex.Undo();
                }
            }
            return new Position(-1, -1);
        }
        /// <summary>
        /// return the postion in which its an immidate win for the ai.
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position EasyWin(GameLogic gl)
        {
            GameLogic ex = new GameLogic(gl);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (PutMe(ex,new Position(i, j)))
                        if (AmIWon(ex))
                            return new Position(i, j);
                        else
                            ex.Undo();
                }
            }
            return new Position(-1, -1);
        }
        /// <summary>
        /// returns the position in which its an immidate win for the player.
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position OEasyWin(GameLogic gl)
        {
            GameLogic ex = new GameLogic(gl);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (PutHim(ex, new Position(i, j)))
                        if (!AmIWon(ex)&&!ex.IsDraw())
                            return new Position(i, j);
                        else
                            ex.Undo();
                }
            }
            return new Position(-1, -1);
        }
        /// <summary>
        /// Tries to do tricks to elevate the AI situation.
        /// </summary>
        /// <param name="gl"></param>
        /// <returns></returns>
        private Position Tricks(GameLogic gl)
        {
            var ex = new GameLogic(gl);
            Stack<Position> corners = new Stack<Position>();
            Stack<Position> sides = new Stack<Position>();
            if (ex.History.Count == 1)
            {
                if (HasInCorner(ex, him, out corners))
                    return new Position(1, 1);
                if (HasInSides(ex, him, out sides))
                    return new Position(1, 1);
                if (ex.board.board[1, 1].player == him)
                    return new Position(0, 0);
            }
            if (Ahead(ex).row != -1)
                return Ahead(ex);
            var pos = ex.AllFreeSpaces();
            Position best = pos[0];
            int best_int = 0;
            for (int i = 0; i < pos.Length; i++)
            {
                PutMe(ex, pos[i]);
                if(WinningWays(ex)>best_int)
                {
                    best_int = WinningWays(ex);
                    best = pos[i];
                }
                ex.Undo();
            }
            return best;
            return new Position(-1, -1);
        }
        /// <summary>
        /// returns if the '<paramref name="player"/>' has occupied cells in the corners.
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing. </param>
        /// <param name="player"></param>
        /// <param name="corners">returns the specified corners which are occupied.</param>
        /// <returns></returns>
        private bool HasInCorner(GameLogic gl,CellE player,out Stack<Position> corners)
        {
            GameLogic ex = new GameLogic(gl);
            corners = new Stack<Position>();
            //if (ex.board.board[0, 1].player == player || ex.board.board[1, 2].player == player || ex.board.board[2, 1].player == player || ex.board.board[01, 0].player == player)
            //  return true;
            if (ex.board.board[0, 0].player == player)
                corners.Push(new Position(0, 0));
            if (ex.board.board[2, 2].player == player)
                corners.Push(new Position(2, 2));
            if (ex.board.board[2, 0].player == player)
                corners.Push(new Position(2, 0));
            if (ex.board.board[0, 2].player == player)
                corners.Push(new Position(0, 2));
            if (corners.Count != 0)
                return true;
                return false;
        }
        /// <summary>
        /// returns true if the '<paramref name="player"/>' has occupid cells in the side of the
        /// board.
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <param name="player"></param>
        /// <param name="sides">returns the specified sides which are occupied.</param>
        /// <returns></returns>
        private bool HasInSides(GameLogic gl, CellE player, out Stack<Position> sides)
        {
            sides = new Stack<Position>();
            if (gl.board.board[0, 1].player == player)
                sides.Push(new Position(0, 1));//
            if (gl.board.board[01, 0].player == player)
                sides.Push(new Position(01, 0));//
            if (gl.board.board[1, 2].player == player)
                sides.Push(new Position(1, 2));//
            if (gl.board.board[02, 1].player == player)
                sides.Push(new Position(02, 1));//
            return sides.Count != 0;
        }
        /// <summary>
        /// returns a move that will make the AI one step from winning (not a trap)
        /// </summary>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position Ahead(GameLogic gl)
        {
            var ex = new GameLogic(gl);
            var a = ex.AllFreeSpaces();
            for (int i = 0; i < a.Length; i++)
            {
                PutMe(ex, a[i]);
                if (EasyWin(ex).row!=-1)
                    return a[i];
                ex.Undo();
            }
            return new Position(-1, -1);
        }
        /// <summary>
        /// Returns in how many ways can the AI win in it next turn.
        /// </summary>
        /// <param name="gl">The game the AI is playing</param>
        /// <returns></returns>
        private int WinningWays(GameLogic gl)
        {
            var ex = new GameLogic(gl);
            var pos = ex.AllFreeSpaces();
            int result = 0, freeSpaces = pos.Length;
            for (int i = 0; i < freeSpaces; i++)
            {
                PutMe(ex, pos[i]);
                if (AmIWon(ex))
                    result++;
                ex.Undo();
            }
            return result;
        }

        private Position block(GameLogic gl)
        {
            Position[] pos = gl.AllPlayerPositions(true);
            for (int i = 0; i < 3; i++)
            {
                if (pos[i] == new Position(0, 0)&&gl.board.board[2,2].player==CellE.empty)
                    return new Position(2, 2);//0,0
                if (pos[i] == new Position(2, 0) && gl.board.board[0, 2].player == CellE.empty)
                    return new Position(0, 2);//2,0
                if (pos[i] == new Position(0, 2) && gl.board.board[2, 0].player == CellE.empty)
                    return new Position(2, 0);//0,2
                if (pos[i] == new Position(2, 2) && gl.board.board[0, 0].player == CellE.empty)
                    return new Position(0, 0);//0,0
            }
            return new Position(-1, -1);
        }
        /// <summary>
        /// return the position of the corner
        /// </summary>
        /// <param name="lr">left or right</param>
        /// <param name="ud">up or down</param>
        /// <returns></returns>
        private Position GetCorner(sides lr,sides ud)
        {
            if (lr == sides.left)
                if (ud == sides.up)
                    return new Position(0, 0);
                else if (ud == sides.down)
                    return new Position(2, 0);
            if (lr == sides.right)
                if (ud == sides.up)
                    return new Position(0, 2);
                else if (ud == sides.down)
                    return new Position(2, 2);
            throw new Exception("lr must be left or right and us must be up or down");
            return new Position(-1, -1);
        }
        /// <summary>
        /// returns the posotion of the side cell.
        /// </summary>
        /// <param name="s">The side</param>
        /// <returns></returns>
        private Position GetSide(sides s)
        {
            return s == sides.up ? new Position(0, 1) : s == sides.down ? new Position(2, 1) : s == sides.left ? new Position(1, 0) : new Position(1, 2);
        }
        private Position BruteForce(GameLogic gl,CellE me)
        {
            return new Position(-1, -1);
        }
        /// <summary>
        /// Do brute force for the AI turn logic
        /// </summary>
        /// <param name="gl"></param>
        /// <param name="p"></param>
        /// <param name="me">the AI sign (X or O)</param>
        /// <returns></returns>
        private int mRBruteForce(GameLogic gl,int current_depth)
        {
            //todo
            depth++;
            var ex = new GameLogic(gl);
            int freespaces = ex.GetFreeSpaces();
            var positions = ex.AllFreeSpaces();
            return -1;
        }
        /// <summary>
        /// Puts the correspond sign of this AI in the <see cref="GameLogic"/> ex.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool PutMe(GameLogic ex,Position p)
        {
            if (me == CellE.o)
                return ex.PutO(p);
            if (me == CellE.x)
                return ex.PutX(p);
            return false;
        }
        private bool PutHim(GameLogic ex, Position p)
        {
            if (me == CellE.o)
                return ex.PutX(p);
            if (me == CellE.x)
                return ex.PutO(p);
            return false;
        }
        private bool DoHimWon(GameLogic ex)
        {
            if (me == CellE.x)
                return ex.IsOWon();
            return ex.IsXWon();
        }
        private bool AmIWon(GameLogic ex)
        {
            if (me == CellE.o)
                return ex.IsOWon();
            return ex.IsXWon();
        }
        /// <summary>
         /// Do brute force for the opponent turn logic
         /// </summary>
         /// <param name="gl"></param>
         /// <param name="p"></param>
         /// <param name="me">the AI sign (X or O)</param>
         /// <returns></returns>
        private int oRBruteForce(GameLogic gl, int current_depth)
        {
            //todo
            depth++;
            var ex = new GameLogic(gl);
            int freespaces = ex.GetFreeSpaces();
            var positions = ex.AllFreeSpaces();
            return -1;
        }
        /// <summary>
        /// returns the cell's position which needed to fill the row.
        /// </summary>
        /// <param name="row">the row to fill</param>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position FillRow(int row,GameLogic gl)
        {
            if (gl.board.board[row, 0].player == CellE.empty)
                if (gl.board.board[row, 1].player != CellE.empty && gl.board.board[row, 2].player != CellE.empty)
                    return new Position(row, 0);//
            if (gl.board.board[row, 1].player == CellE.empty)
                if (gl.board.board[row, 0].player != CellE.empty && gl.board.board[row, 2].player != CellE.empty)
                    return new Position(row, 1);//
            if (gl.board.board[row, 2].player == CellE.empty)
                if (gl.board.board[row, 1].player != CellE.empty && gl.board.board[row, 0].player != CellE.empty)
                    return new Position(row, 2);
            return new Position(-1, -1);
        }
        /// <summary>
        /// returns the cell's position  which needed to fill the col.
        /// </summary>
        /// <param name="col">the col to fill.</param>
        /// <param name="gl">The <seealso cref="GameLogic"/> of the game the ai playing.</param>
        /// <returns></returns>
        private Position FillCol(int col, GameLogic gl)
        {
            if (gl.board.board[0, col].player == CellE.empty)
                if (gl.board.board[1, col].player != CellE.empty && gl.board.board[2, col].player != CellE.empty)
                    return new Position(0, col);//
            if (gl.board.board[1, col].player == CellE.empty)
                if (gl.board.board[0, col].player != CellE.empty && gl.board.board[2, col].player != CellE.empty)
                    return new Position(1, col);//
            if (gl.board.board[2, col].player == CellE.empty)
                if (gl.board.board[1, col].player != CellE.empty && gl.board.board[0, col].player != CellE.empty)
                    return new Position(2, col);
            return new Position(-1, -1);
        }
        //private Position FillDig(int)

    }
}
