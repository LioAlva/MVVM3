using MVVM3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM3.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
