using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public enum CellValue
    {
        Empty,
        X,
        O
    }

    public class Cell
    {
        public CellValue Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Value = CellValue.Empty;
        }
        public override string ToString()
        {
            switch (Value)
            {
                case CellValue.Empty:
                    return " ";
                case CellValue.X:
                    return "X";
                case CellValue.O:
                    return "O";
                default:
                    return " ";
            }
        }
    }
}