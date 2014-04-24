using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTuple
{
    class Program
    {

        public static bool IsPrime(int number)
        {
            if (number==2)
	        {
                return true;
	        }
            int end = (int)Math.Sqrt(number*1.0) + 1;
            if (number%2==0)
            {
                return false;
            }
            for (int i = 3; i < end; i=i+2)
			{
                if (number%i == 0)
                {
                    return false;
                }
			}
            return true;
        }

        public static string goldbach(int n)
        {
            List<string> result = new List<string>();
            int interval = n / 2;
            bool leftSide = false, rightSide = false;
            int left, right;

            StringBuilder sb = new StringBuilder();
            sb.Append(n);

            for (int i = 2; i < interval; i++)
            {
                left = i;
                right = n - i;

                leftSide = IsPrime(left);
                rightSide = IsPrime(right);

                if (leftSide == true && rightSide == true)
                {
                    sb.Append(" = ");
                    sb.Append(left);
                    sb.Append(" + ");
                    sb.Append(right);
                }

            }

            for (int i = 0; i < result.Count; i++)
            {
                sb.Append(result[i]);
            }

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            string str = goldbach(100);
        }
    }
}
