using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Grid
    {
        private Cell[,] cells;

        public Grid(int rows, int columns)
        {
            cells = new Cell[rows, columns];
            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(i, j);
                    cells[i, j].Value = CellValue.Empty;
                }
            }
        }


        public Cell GetCell(int row, int column)
        {
            if (row < 0 || row >= cells.GetLength(0) || column < 0 || column >= cells.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Invalid cell coordinates");
            }

            return cells[row, column];
        }

        public void SetCell(int row, int column, CellValue value)
        {
            if (row < 0 || row >= cells.GetLength(0) || column < 0 || column >= cells.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Invalid cell coordinates");
            }

            cells[row, column].Value = value;
        }

        public Cell[,] GetGrid()
        {
            return cells;
        }

        public int GetRows()
        {
            return cells.GetLength(0);
        }
        public int GetColumns()
        {
            return cells.GetLength(1);
        }
    }
}
