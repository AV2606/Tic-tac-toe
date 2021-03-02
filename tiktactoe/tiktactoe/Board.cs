using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiktactoe
{
    [DebuggerDisplay("state={DBAS()}")]
    public class Board
    {
        public Cell[,] board { get; private set; }
        private string state { get => DBAS(); set => DBAS(); }

        public Board()
        {
            board = new Cell[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = new Cell(new Position(i, j));
                }
            }
        }
        public string DBAS()
        {
            string s = "";
            int i = 1;
            foreach(Cell cell in board)
            {
                s += cell.player == CellE.empty ? "E," : cell.player == CellE.x ? "x," : "o,";
                if (i % 3 == 0)
                    s += "      ";
                i++;
            }
            return s;
        }
        public Board(Board b)
        {
            board = new Cell[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = new Cell(b.board[i,j]);
                }
            }
        }
        /// <summary>
        /// Change the player type that occupies the cell
        /// </summary>
        /// <param name="ce">type of player to fill with</param>
        /// <param name="c">the cell to change</param>
        /// <returns>true if cell was empty and succed t change the player type, otherwise return false</returns>
        public bool changeCellFill (Cell c,CellE ce)
        {
            return board[c.position.row, c.position.col].ChangePlayer(ce);
        }
        public bool IsPlayer1Won(out List<Position> positions)
        {
            positions = new List<Position>();//
            if (board[0, 0].player == (CellE)1)
            {
                positions.Add(new Position(0, 0));//
                if ((board[0, 1].player == (CellE)1))
                {
                    positions.Add(new Position(0, 1));//
                    if (board[0, 2].player == (CellE)1)
                    {
                        positions.Add(new Position(0, 2));//
                        return true;
                    }
                }
                var temp = positions[0];
                positions = new List<Position>();
                positions.Add(temp);
                if (board[1, 0].player == (CellE)1)
                {
                    positions.Add(new Position(1, 0));//
                    if (board[2, 0].player == (CellE)1)
                    {
                        positions.Add(new Position(2, 0));//
                        return true;
                    }
                }
                temp = positions[0];
                positions = new List<Position>();
                positions.Add(temp);
                if (board[1, 1].player == (CellE)1)
                {
                    positions.Add(new Position(1, 1));//
                    if (board[2, 2].player == (CellE)1)
                    {
                        positions.Add(new Position(2, 2));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[1, 0].player == (CellE)1))
            {
                positions.Add(new Position(1, 0));//
                if (board[1, 2].player == (CellE)1)
                {
                    positions.Add(new Position(1, 2));//
                    if ((board[1, 1].player == (CellE)1))
                    {
                        positions.Add(new Position(1, 1));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[2, 0].player == (CellE)1))
            {
                positions.Add(new Position(2, 0));//
                if (board[2, 2].player == (CellE)1)
                {
                    positions.Add(new Position(2, 2));//
                    if ((board[2, 1].player == (CellE)1))
                    {
                        positions.Add(new Position(2, 1));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[0, 1].player == (CellE)1))
            {
                positions.Add(new Position(0, 1));//
                if (board[1, 1].player == (CellE)1)
                {
                    positions.Add(new Position(1, 1));//
                    if ((board[2, 1].player == (CellE)1))
                    {
                        positions.Add(new Position(2, 1));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[0, 2].player == (CellE)1))
            {
                positions.Add(new Position(0, 2));//
                if (board[1, 2].player == (CellE)1)
                {
                    positions.Add(new Position(1, 2));//
                    if ((board[2, 2].player == (CellE)1))
                    {
                        positions.Add(new Position(2, 2));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[0, 2].player == (CellE)1))
            {
                positions.Add(new Position(0, 2));//
                if (board[1, 1].player == (CellE)1)
                {
                    positions.Add(new Position(1, 1));//
                    if ((board[2, 0].player == (CellE)1))
                    {
                        positions.Add(new Position(2, 0));//
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsPlayer2Won(out List<Position> positions)
        {
            positions = new List<Position>();//
            if (board[0, 0].player == (CellE)2)
            {
                positions.Add(new Position(0, 0));//
                if ((board[0, 1].player == (CellE)2))
                {
                    positions.Add(new Position(0, 1));//
                    if (board[0, 2].player == (CellE)2)
                    {
                        positions.Add(new Position(0, 2));//
                        return true;
                    }
                }
                var temp = positions[0];
                positions = new List<Position>();
                positions.Add(temp);
                if (board[1, 0].player == (CellE)2)
                {
                    positions.Add(new Position(1, 0));//
                    if (board[2, 0].player == (CellE)2)
                    {
                        positions.Add(new Position(2, 0));//
                        return true;
                    }
                }
                temp = positions[0];
                positions = new List<Position>();
                positions.Add(temp);
                if (board[1, 1].player == (CellE)2)
                {
                    positions.Add(new Position(1, 1));//
                    if (board[2, 2].player == (CellE)2)
                    {
                        positions.Add(new Position(2, 2));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[1, 0].player == (CellE)2))
            {
                positions.Add(new Position(1, 0));//
                if (board[1, 2].player == (CellE)2)
                {
                    positions.Add(new Position(1, 2));//
                    if ((board[1, 1].player == (CellE)2))
                    {
                        positions.Add(new Position(1, 1));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[2, 0].player == (CellE)2))
            {
                positions.Add(new Position(2, 0));//
                if (board[2, 2].player == (CellE)2)
                {
                    positions.Add(new Position(2, 2));//
                    if ((board[2, 1].player == (CellE)2))
                    {
                        positions.Add(new Position(2, 1));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[0, 1].player == (CellE)2))
            {
                positions.Add(new Position(0, 1));//
                if (board[1, 1].player == (CellE)2)
                {
                    positions.Add(new Position(1, 1));//
                    if ((board[2, 1].player == (CellE)2))
                    {
                        positions.Add(new Position(2, 1));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[0, 2].player == (CellE)2))
            {
                positions.Add(new Position(0, 2));//
                if (board[1, 2].player == (CellE)2)
                {
                    positions.Add(new Position(1, 2));//
                    if ((board[2, 2].player == (CellE)2))
                    {
                        positions.Add(new Position(2, 2));//
                        return true;
                    }
                }
            }
            positions.Clear();//
            if ((board[0, 2].player == (CellE)2))
            {
                positions.Add(new Position(0, 2));//
                if (board[1, 1].player == (CellE)2)
                {
                    positions.Add(new Position(1, 1));//
                    if ((board[2, 0].player == (CellE)2))
                    {
                        positions.Add(new Position(2, 0));//
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsPlayer1Won()
        {
            if(board[0,0].player==(CellE)1)
            {
                if ((board[0, 1].player == (CellE)1))
                    if (board[0, 2].player == (CellE)1)
                        return true;
                if (board[1, 0].player == (CellE)1)
                    if (board[2, 0].player == (CellE)1)
                        return true;
                if (board[1, 1].player == (CellE)1)
                    if (board[2, 2].player == (CellE)1)
                        return true;
            }
            if ((board[1, 0].player == (CellE)1))
                if (board[1, 2].player == (CellE)1)
                    if ((board[1, 1].player == (CellE)1))
                        return true;
            if ((board[2, 0].player == (CellE)1))
                if (board[2, 2].player == (CellE)1)
                    if ((board[2, 1].player == (CellE)1))
                        return true;
            if ((board[0, 1].player == (CellE)1))
                if (board[1, 1].player == (CellE)1)
                    if ((board[2, 1].player == (CellE)1))
                        return true;
            if ((board[0, 2].player == (CellE)1))
                if (board[1, 2].player == (CellE)1)
                    if ((board[2, 2].player == (CellE)1))
                        return true;
            if ((board[0, 2].player == (CellE)1))
                if (board[1, 1].player == (CellE)1)
                    if ((board[2, 0].player == (CellE)1))
                        return true;
            return false;
        }
        public bool IsPlayer2Won()
        {
            if (board[0, 0].player == (CellE)2)
            {
                if ((board[0, 1].player == (CellE)2))
                    if (board[0, 2].player == (CellE)2)
                        return true;
                if (board[1, 0].player == (CellE)2)
                    if (board[2, 0].player == (CellE)2)
                        return true;
                if (board[1, 1].player == (CellE)2)
                    if (board[2, 2].player == (CellE)2)
                        return true;
            }
            if ((board[1, 0].player == (CellE)2))
                if (board[1, 2].player == (CellE)2)
                    if ((board[1, 1].player == (CellE)2))
                        return true;
            if ((board[2, 0].player == (CellE)2))
                if (board[2, 2].player == (CellE)2)
                    if ((board[2, 1].player == (CellE)2))
                        return true;
            if ((board[0, 1].player == (CellE)2))
                if (board[1, 1].player == (CellE)2)
                    if ((board[2, 1].player == (CellE)2))
                        return true;
            if ((board[0, 2].player == (CellE)2))
                if (board[1, 2].player == (CellE)2)
                    if ((board[2, 2].player == (CellE)2))
                        return true;
            if ((board[0, 2].player == (CellE)2))
                if (board[1, 1].player == (CellE)2)
                    if ((board[2, 0].player == (CellE)2))
                        return true;
            return false;
        }
        public bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j].player == 0)
                        return false;
                }
            }
            return IsPlayer1Won() ? false : IsPlayer2Won() ? false : true;

        }
        public bool Clear()
        {

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = new Cell(new Position(i, j));
                    }
                }
            }
            catch (Exception e) { return false; }
            return true;
        }
        public int EmptyCells()
        {
            int ret = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j].player == CellE.empty)
                        ret++;
            return ret;
        }
    }
}
