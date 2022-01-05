using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSearch
{
    public interface IContainerPresenter
    {
        void Initialize();
        void Search(string searchFor);
        ContainerModel GetItemAt(int index);
    }
}
