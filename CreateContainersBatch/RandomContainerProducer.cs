using ContainerCheckDigitCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    public class RandomContainerProducer : IRandomContainerProducer
    {
        public void GenerateAndSave(int count, IContainerPersisterService persister)
        {
            string peek = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] types =
            {
                "20 DRY VAN",
                "40 DRY VAN",
                "20 HIGH CUBE",
                "40 HIGH CUBE",
            };
            var rnd = new Random();
            var calc = new CheckDigitCalculator();
            persister.BeginPersistence();
            for (int i = 0; i < count; i++)
            {
                string code = string.Concat("MS", peek.Substring(rnd.Next(0, peek.Length), 1),"U");
                var digits = rnd.Next(99999, 1000000).ToString("000000");
                var check = calc.CalculateCheckDigit(string.Concat(code, digits));
                persister.Persist(string.Concat(code, digits, check.ToString()),
                    types[rnd.Next(0,types.Length)],
                    DateTime.Today.AddDays(-rnd.Next(0,121))
                    );

            }
            persister.EndPersistence();
        }
    }
}
