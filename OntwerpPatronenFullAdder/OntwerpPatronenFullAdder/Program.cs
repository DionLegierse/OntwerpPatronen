using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Er wordt een nieuw circuit gemaakt en vanuit de argumenten wordt de file meegegeven
            Circuit circuit = new Circuit(args[0]);

            //Het circuit wordt gesimuleerd
            circuit.Simulate();
            Console.ReadKey();
        }
    }
}
