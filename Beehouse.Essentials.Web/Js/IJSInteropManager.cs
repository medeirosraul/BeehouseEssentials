using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Web.Js
{
    public interface IJSInteropManager
    {
        void AddFunction(string function);

        Task Run();
    }
}
