using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Web.Js
{
    public class JSInteropManager : IJSInteropManager
    {
        private readonly IJSRuntime _runtime;

        private List<string> _functions;

        public JSInteropManager(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public void AddFunction(string function)
        {
            if (_functions == null)
                _functions = new List<string>();

            if (_functions.Any(p => p.Equals(function))) return;

            _functions.Add(function);
        }

        public async Task Run()
        {
            if (_functions == null || _functions.Count == 0)
                return;

            _functions.ForEach(async (p) =>
            {
                try
                {
                    await _runtime.InvokeAsync<object>(p).ConfigureAwait(false);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Não foi possível executar a função Javascript \"{p}\".\n{e.Message}");
                }
            });
        }
    }
}
