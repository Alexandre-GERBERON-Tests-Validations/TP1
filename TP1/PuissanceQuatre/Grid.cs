using System;

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
            int rowCount = cells.GetLength(0);
            int columnCount = cells.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    cells[i, j] = new Cell(i, j)
                    {
                        Value = CellValue.Empty
                    };
                }
            }
        }

        public Cell GetCell(int row, int column)
        {
            int rowCount = cells.GetLength(0);
            int columnCount = cells.GetLength(1);

            if (row < 0 || row >= rowCount || column < 0 || column >= columnCount)
            {
                throw new ArgumentOutOfRangeException("Invalid cell coordinates");
            }

            return cells[row, column];
        }

        public void SetCell(int row, int column, CellValue value)
        {
            int rowCount = cells.GetLength(0);
            int columnCount = cells.GetLength(1);

            if (row < 0 || row >= rowCount || column < 0 || column >= columnCount)
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
