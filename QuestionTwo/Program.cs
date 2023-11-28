using System;

namespace QuestionTwo
{
    public class Program
    {
        public static int[,] generateMatrix(int[] matrix, int rows, int columns)
        {
            int[,] result = new int[rows, columns];
            for (int rowIdx = 0; rowIdx < rows; rowIdx++)
            {
                for (int colIdx = 0; colIdx < columns; colIdx++)
                {
                    result[rowIdx, colIdx] = matrix[rowIdx * columns + colIdx];
                }
            }

            return result;
        }

        public static string UnrollMatrix(int[] matrix, int rows, int columns)
        {
            int top = 0, bottom = rows - 1, left = 0, right = columns - 1;
            int dir = 1;

            string result = string.Empty;

            int[,] arr = generateMatrix(matrix, rows, columns);

            while (top <= bottom && left <= right)
            {

                if (dir == 1)
                {    
                    for (int i = left; i <= right; ++i)
                    {
                        result += arr[top, i] + " ";
                    }
                    ++top;
                    dir = 2;
                }
                else if (dir == 2)
                { 
                    for (int i = top; i <= bottom; ++i)
                    {
                        result += arr[i, right] + " ";
                    }
                    --right;
                    dir = 3;
                }
                else if (dir == 3)
                {     
                    for (int i = right; i >= left; --i)
                    {
                        result += arr[bottom, i] + " ";
                    }
                    --bottom;
                    dir = 4;
                }
                else if (dir == 4)
                {    
                    for (int i = bottom; i >= top; --i)
                    {
                        result += arr[i, left] + " ";
                    }
                    ++left;
                    dir = 1;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[] maxtrix = { 0, 1, 2, 3, 4, 5, 6, 7, 8 , 9, 10, 11};
            string result = UnrollMatrix(maxtrix, 4, 3);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
