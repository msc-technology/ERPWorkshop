using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    public interface IRandomContainerProducer
    {
        void GenerateAndSave(int count, IContainerPersisterService persister);
    }
}
