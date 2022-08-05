using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies.Interface
{
    public interface IDependencyRegistrar<TInjector>
    {
        void Register(TInjector injector,object additional);
    }
}
