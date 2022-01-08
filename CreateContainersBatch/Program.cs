using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new RandomContainerProducer();
            generator.GenerateAndSave(1000, new SqlBulkPersister());
        }
    }
}
