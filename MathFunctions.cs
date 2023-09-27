using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RSAConsole
{
	internal class MathFunctions
	{

		public static long FastExponentiation(long number, long power, long n )
		{
			long result = 1;
			for (long i = 0; i < power; i++)
			{
				result = result * number % n;
			}
			return result;
		}

		public static int GCD(int a, int b)
		{
			if (b == 0)
				return a;
			return GCD(b, a % b);
		}

		public static int EulersTotientFunction(float p1, float p2)
		{
			return (int)((p1 - 1) * (p2 - 1));
		}

		public static List<int> PrimesUpToN(int n)
		{
			List<bool> a = Enumerable.Repeat(true, n + 1).ToList();
			for (float i = 2; i <= Math.Sqrt(n); i++)
			{
				if (a[(int)i] == true)
				{
					int j = (int)i * (int)i;
					while (j <= n)
					{
						a[j] = false;
						j = j + (int)i;
					}
				}
			}

			List<int> primes = new List<int>();
			for (int i = 2; i <= n; i++)
			{
				if (a[i] == true)
				{
					primes.Add(i);
				}
			}
			return primes;
		}
	}
}
