using System.Security.Cryptography;
using System;

namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
		public RandomService()
		{
			seed = Guid.NewGuid().GetHashCode();
		}
		public int GetRandom()
        {
            // . Retirar o seed corrige a função e devolve números aleatórios
            //return new Random().Next(100);

            // . Usar RandomNumberGenerator tem melhor performance à partir do Net3+
            return RandomNumberGenerator.GetInt32(1, 100);
        }

	}
}
