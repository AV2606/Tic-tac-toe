using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace tiktactoe
{
    [DebuggerDisplay("board status={board.DBAS()}")]
    public class GameLogic
    {
        public Board board { get; private set; }
        public Stack<Position> History { get; private set; }

        public GameLogic()
        {
            board = new Board();
            History = new Stack<Position>();
        }
        /// <summary>
        /// returns a copy of <paramref name="gl"/>
        /// </summary>
        /// <param name="gl">the game logic to copy</param>
        public GameLogic(GameLogic gl)
        {
            /*var temp = gl.MemberwiseClone();
            if (temp == gl)
                throw new Exception();
            board = gl.board;
            History = gl.History;*/
            board = new Board(gl.board);
            History = new Stack<Position>();
            var glH = gl.History.ToArray();
            foreach (var item in glH)
                this.History.Push(item);
        }
        /// <summary>
        /// tries to put X player in the <seealso cref="Position"/> p and return true if succed, and false otherwise.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool PutX (Position p)
        {
            if (board.changeCellFill((Cell)p, CellE.x))
            {
                History.Push(p);
                return true;
            }
            return false;
        }
        public bool PutX(int row,int col)
        {
            return PutX(new Position(row, col));
        }
        /// <summary>
        /// tries to put O player in the <seealso cref="Position"/> p and return true if succed, and false otherwise.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool PutO (Position p)
        {
             if(board.changeCellFill((Cell)p, CellE.o))
            {
                History.Push(p);
                return true;
            }
            return false;
        }
        public bool PutO (int row,int col)
        {
            return PutO(new Position(row, col));
        }
        /// <summary>
        /// Returns the Amount of free spaces in the <seealso cref="board"/>
        /// </summary>
        /// <returns></returns>
        public int GetFreeSpaces()
        {
            int ret = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.board[i, j].player == CellE.empty)
                        ret++;
                }
            }
            return ret;
        }
        public void Clear()
        {
            var a=board.Clear();
            History = new Stack<Position>();
        }
        public Position Undo()
        {
            if (History.Count == 0)
                return new Position(-1,-1);
            var temp = new Cell(History.Peek());
            board.board[History.Peek().row, History.Peek().col] = new Cell(temp);
            History.Pop();
            if (Program.Game.IsAILastTurned())
                if (History.Count != 0)
                    History.Pop();
            return temp.position;
        }
        /// <summary>
        /// return true if X won and false otherwise
        /// </summary>
        /// <returns></returns>
        public bool IsXWon()
        {
            return board.IsPlayer1Won();
        }
        /// <summary>
        /// returns true if O won and false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool IsOWon()
        {
            return board.IsPlayer2Won();
        }
        /// <summary>
        /// return true if X won and false otherwise
        /// </summary>
        /// <returns></returns>
        public bool IsXWon(out List<Position> positions)
        {
            return board.IsPlayer1Won(out positions);
        }
        /// <summary>
        /// returns true if O won and false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool IsOWon(out List<Position> positions)
        {
            return board.IsPlayer2Won(out positions);
        }
        /// <summary>
        /// returns true if the game ended with a draw.
        /// <para>if X won, O won or the game didnt finish reutns false</para>
        /// </summary>
        /// <returns></returns>
        public bool IsDraw()
        {
            return board.IsDraw();
        }
        /// <summary>
        /// get all position of x or o
        /// </summary>
        /// <param name="X">true for xs, false for os</param>
        /// <returns></returns>
        public Position[] AllPlayerPositions(bool X)
        {
            Queue<Position> pos = new Queue<Position>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (X && board.board[i, j].player == CellE.x)
                        pos.Enqueue(board.board[i, j].position);
                    else
                        if (!X && board.board[i, j].player == CellE.o)
                        pos.Enqueue(board.board[i, j].position);
                }
            }
            return pos.ToArray();
        }
        public Position[] AllFreeSpaces()
        {
            Stack<Position> pos = new Stack<Position>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.board[i, j].player == CellE.empty)
                        pos.Push(new Position(i, j));
                }
            }
            return pos.ToArray();
        }
    }
}
