using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    public class SqlNaivePersister : IContainerPersisterService
    {
        
        public void BeginPersistence()
        {
            throw new NotImplementedException();
        }

        public void EndPersistence()
        {
            throw new NotImplementedException();
        }

        public void Persist(string containerCode, string containerType, DateTime hireDate)
        {
            throw new NotImplementedException();
        }

       
    }
}
