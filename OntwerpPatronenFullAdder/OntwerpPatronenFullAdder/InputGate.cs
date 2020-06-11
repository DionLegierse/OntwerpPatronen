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

        //Als deze er is, dan is het al goed
        public override bool IsConnectedCorrect()
        {
            return true;
        }
    }
}
