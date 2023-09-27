using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RSAConsole
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int size = 1000;
			List<int> primes = MathFunctions.PrimesUpToN(size);
			Random random = new Random();
			int p1 = primes[random.Next(primes.Count)];
			int p2 = primes[random.Next(primes.Count)];

			while (p1 == p2)
				p2 = primes[random.Next(primes.Count)];

			int N = p1 * p2;
			int FN = MathFunctions.EulersTotientFunction(p1, p2);

			int E = 2;
			while (MathFunctions.GCD(E, FN) != 1)
				E++;

			int D = 1;
			while (D * E % FN != 1)
				D++;

			string text = "hello abc 12";

			UnicodeEncoding byteConverter = new UnicodeEncoding();
			Console.WriteLine($"p1 = {p1},p2 = {p2}");
			Console.WriteLine($"PLAIN TEXT = {text}");

			long[] C = new long[text.Length];
            for (int i = 0; i<C.Length; i++)
			{
				C[i] = MathFunctions.FastExponentiation(Convert.ToInt32(text[i]), E, N);
			}

			StringBuilder sb = new StringBuilder();
			int counter = 0;
			Console.WriteLine($"ENCRYPTED CODES");
			foreach (var item in C)
            {
				counter++;
				sb.Append(Convert.ToChar((byte)item));
				
				if(counter != 8)
				{
					Console.Write(item.ToString() + "\t");
				}
				else
				{
					Console.Write(item.ToString() + "\n");
					counter = 0;
				}
			}
			Console.WriteLine($"\nCRYPTED = {sb}");

			long[] P = new long[text.Length];
			for (int i = 0; i < P.Length; i++)
			{
				P[i] = MathFunctions.FastExponentiation(Convert.ToInt32(C[i]), D, N);
			}

			StringBuilder sb2 = new StringBuilder();
			counter = 0;
			Console.WriteLine($"DECRYPTED CODES");
			foreach (var item in P)
			{
				counter++;
				sb2.Append(Convert.ToChar((byte)item));
				if (counter != 8)
				{
					Console.Write(item.ToString() + "\t");
				}
				else
				{
					Console.Write(item.ToString() + "\n");
					counter = 0;
				}
			}
			Console.WriteLine($"\nDECRYPTED = {sb2}");

		}
	}
}
