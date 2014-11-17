using System;

public class RotatingWalkMatrix
{
    private static void ChangeDirection(ref int directionX, ref int directionY)
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int currentDirection = 0;
        for (int count = 0; count < directionsX.Length; count++)
        {
            if (directionsX[count] == directionX && directionsY[count] == directionY)
            {
                currentDirection = count;
                break;
            }
        }

        if (currentDirection == (directionsX.Length - 1))
        {
            directionX = directionsX[0];
            directionY = directionsY[0];
            return;
        }

        directionX = directionsX[currentDirection + 1];
        directionY = directionsY[currentDirection + 1];
    }

    private static bool CheckCellForNextMove(int[,] matrix, int row, int col)
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < directionsX.Length; i++)
        {
            if (row + directionsX[i] >= matrix.GetLength(0) || row + directionsX[i] < 0)
            {
                directionsX[i] = 0;
            }

            if (col + directionsY[i] >= matrix.GetLength(1) || col + directionsY[i] < 0)
            {
                directionsY[i] = 0;
            }
        }

        for (int i = 0; i < directionsX.Length; i++)
        {
            if (matrix[row + directionsX[i], col + directionsY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static void FindStartCellForSecondHalf(int[,] matrix, out int row, out int col)
    {
        row = 0;
        col = 0;
        for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
        {
            for (int currentCol = 0; currentCol < matrix.GetLength(0); currentCol++)
            {
                if (matrix[currentRow, currentCol] == 0)
                {
                    row = currentRow;
                    col = currentCol;
                    return;
                }
            }
        }
    }

    public static int[,] BuildMatrix(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        int currentValue = 1;
        int row = 0;
        int col = 0;

        CreateHalfMatrix(matrix, ref row, ref col, ref currentValue);

        currentValue++;

        FindStartCellForSecondHalf(matrix, out row, out col);

        if (row != 0 && col != 0)
        {
            CreateHalfMatrix(matrix, ref row, ref col, ref currentValue);
        }

        return matrix;
    }

    private static void CreateHalfMatrix(int[,] matrix, ref int row, ref int col, ref int currentValue)
    {
        int directionX = 1;
        int directionY = 1;
        int matrixSize = matrix.GetLength(0);

        while (true)
        {
            matrix[row, col] = currentValue;

            if (!CheckCellForNextMove(matrix, row, col))
            {
                break;
            }

            while ((row + directionX >= matrixSize || row + directionX < 0 ||
                    col + directionY >= matrixSize || col + directionY < 0 ||
                    matrix[row + directionX, col + directionY] != 0))
            {
                ChangeDirection(ref directionX, ref directionY);
            }

            row += directionX;
            col += directionY;
            currentValue++;
        }
    }

    private static void PrintMatrixToConsole(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static int ReadMatrixSizeFromConsole()
    {
        Console.WriteLine("Enter a matrix size");
        string input = Console.ReadLine();
        int number;
        while (!int.TryParse(input, out number) || number < 0 || number > 100)
        {
            Console.WriteLine("You haven't entered a correct positive size number");
            input = Console.ReadLine();
        }
        return number;
    }

    public static void Main()
    {
        int matrixSize = ReadMatrixSizeFromConsole();

        int[,] matrix = BuildMatrix(matrixSize);

        PrintMatrixToConsole(matrix);
    }
}
