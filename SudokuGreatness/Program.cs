using System;
using System.Collections.Generic;

namespace SudokuGreatness
{
    class Program
    {

        public static void Main(String[] args)
        {
            List<List<int>> Sudoku = new List<List<int>>();
            Sudoku.Add(new List<int>() { 5, 3, 0, 0, 7, 0, 0, 0, 0 });
            Sudoku.Add(new List<int>() { 6, 0, 0, 1, 9, 5, 0, 0, 0 });
            Sudoku.Add(new List<int>() { 0, 9, 8, 0, 0, 0, 0, 6, 0 });
            Sudoku.Add(new List<int>() { 8, 0, 0, 0, 6, 0, 0, 0, 3 });
            Sudoku.Add(new List<int>() { 4, 0, 0, 8, 0, 3, 0, 0, 1 });
            Sudoku.Add(new List<int>() { 7, 0, 0, 0, 2, 0, 0, 0, 6 });
            Sudoku.Add(new List<int>() { 0, 6, 0, 0, 0, 0, 2, 8, 0 });
            Sudoku.Add(new List<int>() { 0, 0, 0, 4, 1, 9, 0, 0, 5 });
            Sudoku.Add(new List<int>() { 0, 0, 0, 0, 8, 0, 0, 7, 9 });

            if (Finish_Sudoku(Sudoku, 9))
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(Sudoku[i][j] + " ");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No solution");
            }
        }

        public static bool FindEmptyCell(List<List<int>> Sudoku, int row, int col, int counter)
        {

            for (int i = 0; i < Sudoku[0].Count; i++)
            {
                if (Sudoku[row][i] == counter)
                {
                    return false;
                }
            }

            for (int j = 0; j < Sudoku[0].Count; j++)
            {
                if (Sudoku[j][col] == counter)
                {
                    return false;
                }
            }

            for (int i = 0; i < Sudoku[0].Count / 3; i++)
            {
                for (int j = 0; j < Sudoku[1].Count / 3; j++)
                {
                    if (Sudoku[(i + (row - row % 3))][(j + (col - col % 3))] == counter)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Allt fyrir ofan þetta, er kóðinn minn.
        // Fyrir neðan, þurfti eg hjálp með.

        public static bool Finish_Sudoku(List<List<int>> Sudoku, int n)
        {
            int row = 0;
            int col = 0;
            bool isZero = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Sudoku[i][j] == 0)
                    {
                        row = i;
                        col = j;

                        isZero = false;

                    }
                }

            }

            if (isZero)
            {
                return true;
            }

            for (int i = 1; i <= n; i++)
            {
                if (FindEmptyCell(Sudoku, row, col, i))
                {
                    Sudoku[row][col] = i;

                    if (Finish_Sudoku(Sudoku, n))
                    {
                        return true;
                    }
                    else
                    {
                        Sudoku[row][col] = 0;
                    }
                }
            }

            return false;

        }

    }
}












