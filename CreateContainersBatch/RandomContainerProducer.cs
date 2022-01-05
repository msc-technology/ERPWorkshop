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
            throw new NotImplementedException();
        }
    }
}
