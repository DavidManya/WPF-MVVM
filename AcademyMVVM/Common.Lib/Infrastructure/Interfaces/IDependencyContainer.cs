using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Infrastructure.Interfaces
{
    public interface IDependencyContainer
    {
        void Register<Tin, Tout>() where Tout : class, Tin, new();
        void Register<Tin, Tout>(Func<object[], object> constructor) where Tout : class, Tin;
        Tin Resolve<Tin>();
        Tin Resolve<Tin>(object[] parameters = default);
    }
}
