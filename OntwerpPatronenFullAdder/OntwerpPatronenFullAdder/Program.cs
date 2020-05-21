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
            Circuit circuit = new Circuit(args[0]);

            circuit.Simulate();
            Console.ReadKey();
        }
    }
}
