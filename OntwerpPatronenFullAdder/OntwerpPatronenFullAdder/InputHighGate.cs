using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputHighGate : InputGate
    {
        public InputHighGate()
        {

        }

        public override bool GetState()
        {
            return true;
        }

        public override IGate Clone()
        {
            return new InputHighGate();
        }

        public override string GetKey()
        {
            return "INPUT_HIGH";
        }
    }
}
