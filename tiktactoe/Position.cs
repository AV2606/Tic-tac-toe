using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiktactoe
{
    public class Position
    {
        public int row { get; private set; }
        public int col { get; private set; }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public Position(int row)
        {
            this.row = row;
        }
        public static Position operator + (Position a, int b)
        {
            return new Position(a.row, b);
        }
        public Position(Position p)
        {
            row = p.row;
            col = p.col;
        }
        private bool Equals(Position p)
        {
            if (row == p.row && col == p.col)
                return true;
            return false;

        }
        public static bool operator == (Position left,Position right)
        {
            return left.Equals(right);
        }
        public static bool operator != (Position left, Position right)
        {
            return !left.Equals(right);
        }
        public override string ToString()
        {
            return row + "," + col;
        }
    }
}
