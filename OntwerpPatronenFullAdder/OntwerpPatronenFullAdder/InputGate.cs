using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputGate : PrototypeGate
    {

        public InputGate()
        {

        }

        public override bool IsConnectedCorrect()
        {
            return true;
        }
    }
}
