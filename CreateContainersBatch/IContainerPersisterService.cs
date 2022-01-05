using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    public interface IContainerPersisterService
    {
        void BeginPersistence();
        void EndPersistence();
        void Persist(string containerCode, string containerType, DateTime hireDate);

    }
}
