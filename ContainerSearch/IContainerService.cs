using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSearch
{
    public interface IContainerService
    {
        ContainerModel[] FetchPage(int offset, int count, string toSearch);
        int GetCount(string toSearch);
    }
}
