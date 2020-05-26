using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputLowGate : InputGate
    {
        public InputLowGate()
        {

        }

        public override bool GetState()
        {
            return false;
        }

        public override IGate Clone()
        {
            return new InputLowGate();
        }
        public override string GetKey()
        {
            return "INPUT_LOW";
        }
    }
}
