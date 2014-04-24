using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signature
{
    class Program
    {
        public static bool magic_square(string matrix)
        {
            char[] spl1 = new char[] { ']' };
            int numOfRow = matrix.Split(spl1,StringSplitOptions.RemoveEmptyEntries).Length;


            char[] spl = new char[] { ' ', ',', '[', ']' };
            string[] splMatrix = matrix.Split(spl,StringSplitOptions.RemoveEmptyEntries);
            int[,] matrixInt = new int[numOfRow, numOfRow];
            int index = 0;
            int number = 0;

            for (int i = 0; i < numOfRow; i++)
            {
                for (int j = 0; j < numOfRow; j++)
                {
                    number = int.Parse(splMatrix[index]);
                    matrixInt[i, j] = number;
                    index++;
                }
            }


            int horizontal = 0;
            int vertical = 0;
            int mainDiag = 0;
            int backDiag = 0;
            int[,] matrixMagic = new int[numOfRow, numOfRow];

            for (int i = 0; i < numOfRow; i++)
            {
                horizontal = 0;
                vertical = 0;
                for (int j = 0; j < numOfRow; j++)
                {
                    horizontal = horizontal+matrixInt[i, j];
                    vertical = vertical+matrixInt[j, i];
                    if (i==j)
                    {
                        mainDiag = mainDiag + matrixInt[i, j];
                    }

                    if (i+j == numOfRow-1)
                    {
                        backDiag = backDiag + matrixInt[i, j];
                    }
                    
                }
                matrixMagic[0, i] = horizontal;
                matrixMagic[1, i] = vertical;
            }


            if (mainDiag != matrixMagic[0,0])
            {
                Console.WriteLine(false);
                return false;
            }
            if (backDiag != mainDiag)
            {
                Console.WriteLine(false);
                return false;
            }

            int temp = matrixMagic[0, 0];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < numOfRow; j++)
                {
                    if (temp != matrixMagic[i,j])
                    {
                        Console.WriteLine(false);
                        return false;
                    }
                }
            }
            Console.WriteLine(true);
            return true;


        }
        static void Main(string[] args)
        {
            bool result;
            result = magic_square("[[1,2,3], [4,5,6], [7,8,9]]");
            result = magic_square("[[4,9,2], [3,5,7], [8,1,6]]");
            result = magic_square("[[7,12,1,14], [2,13,8,11], [16,3,10,5], [9,6,15,4]]");
            result = magic_square("[[23, 28, 21], [22, 24, 26], [27, 20, 25]]");
            result=magic_square("[[16, 23, 17], [78, 32, 21], [17, 16, 15]]");
        }
    }
}
