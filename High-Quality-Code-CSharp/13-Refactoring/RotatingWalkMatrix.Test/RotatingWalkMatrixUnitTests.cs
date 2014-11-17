using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace RotatingWalkMatrixTest
{
    [TestClass]
    public class RotatingWalkMatrixUnitTests
    {
        [TestMethod]
        public void TestSize2()
        {
            int number = 2;
            int[,] expectedMatrix = 
            {
                {1, 4},
                {3, 2}
            };

            int[,] actualMatrix = RotatingWalkMatrix.BuildMatrix(number);
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix, "Matrix with invalid size 2x2");
        }

        [TestMethod]
        public void TestSize4()
        {
            int number = 4;
            int[,] expectedMatrix = 
            {
                {1, 10, 11, 12},
                {9, 2, 15, 13},
                {8, 16, 3, 14},
                {7, 6, 5, 4}
            };

            int[,] actualMatrix = RotatingWalkMatrix.BuildMatrix(number);
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix, "Matrix with invalid size 4x4");
        }

        [TestMethod]
        public void TestSize6()
        {
            int number = 6;
            int[,] expectedMatrix = 
            {
                {1, 16, 17, 18, 19, 20},
                {15, 2, 27, 28, 29, 21},
                {14, 31, 3, 26, 30, 22},
                {13, 36, 32, 4, 25, 23},
                {12, 35, 34, 33, 5, 24},
                {11, 10, 9, 8, 7, 6}

            };

            int[,] actualMatrix = RotatingWalkMatrix.BuildMatrix(number);
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix, "Matrix with invalid size 6x6");
        }

        [TestMethod]
        public void TestSize14()
        {
            int number = 14;
            int[,] expectedMatrix = 
            {
                 {1,   40,  41,  42,  43,  44,  45,  46,  47,  48,  49,  50, 51, 52},
                 {39,   2,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84, 85, 53},
                 {38, 131,   3,  74, 102, 103, 104, 105, 106, 107, 108, 109, 86, 54},
                 {37, 160, 132,   4,  73, 101, 120, 121, 122, 123, 124, 110, 87, 55},
                 {36, 159, 161, 133,   5,  72, 100, 119, 129, 130, 125, 111, 88, 56},
                 {35, 158, 181, 162, 134,   6,  71,  99, 118, 128, 126, 112, 89, 57},
                 {34, 157, 180, 182, 163, 135,   7,  70,  98, 117, 127, 113, 90, 58},
                 {33, 156, 179, 193, 183, 164, 136,   8,  69,  97, 116, 114, 91, 59},
                 {32, 155, 178, 192, 194, 184, 165, 137,   9,  68,  96, 115, 92, 60},
                 {31, 154, 177, 191, 196, 195, 185, 166, 138,  10,  67,  95, 93, 61},
                 {30, 153, 176, 190, 189, 188, 187, 186, 167, 139,  11,  66, 94, 62},
                 {29, 152, 175, 174, 173, 172, 171, 170, 169, 168, 140,  12, 65, 63},
                 {28, 151, 150, 149, 148, 147, 146, 145, 144, 143, 142, 141, 13, 64},
                 {27,  26,  25,  24,  23,  22,  21,  20,  19,  18,  17,  16, 15, 14}

            };

            int[,] actualMatrix = RotatingWalkMatrix.BuildMatrix(number);
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix, "Matrix with invalid size 14x14");
        }
    }
}