using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class CircuitFactory : IDisposable
    {
        bool Disposed = false;

        List<Dictionary<string, string>> ReadComponents;

        public CircuitFactory()
        {
            ReadComponents = new List<Dictionary<string, string>>();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
                
            }

            Disposed = true;
        }

        ~CircuitFactory()
        {
            Dispose(false);
        }

        public void BuildCircuit()
        {
            // TODO: Implementatie van FileReader klasse bekijken en daarop aanpassen
            //FileReader readFile = new FileReader();
            //ReadComponents.Add(readfile.NextComponent());
        }

        public void AddComponent()
        {

        }
    }
}
