using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiktactoe
{
    /// <summary>
    /// Represent what the cell contains.
    /// </summary>
    public enum CellE { empty,x,o,};
    public class Cell
    {
        public Position position { get; private set; }
        public CellE player { get; protected set; }

        public Cell(Position p)
        {
            position = p;
            player = CellE.empty;
        }
        /// <summary>
        /// Create an new cell with the same arritbutes.
        /// </summary>
        /// <param name="c">the cell to copy</param>
        public Cell(Cell c)
        {
            position = new Position(c.position);
            player = c.player;
        }

        public static explicit operator Cell(Position p)
        {
            return new Cell(p);
        }

        public bool ChangePlayer(int p)
        {
            return ChangePlayer((CellE)p);
        }
        /// <summary>
        /// Change the player type that occupies the cell
        /// </summary>
        /// <param name="p">type of player to fill with</param>
        /// <returns>true if cell was empty and succed t change the player type, otherwise return false</returns>
        public bool ChangePlayer(CellE p)
        {
            if (player!=CellE.empty)
                return false;
            player = p;
            return true;
        }
    }
}
