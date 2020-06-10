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

        //Returnt state high, 1
        public override bool GetState()
        {
            return true;
        }

        //Maakt een clone van de gate
        public override IGate Clone()
        {
            return new InputHighGate();
        }

        //Returnt de naam van de gate
        public override string GetKey()
        {
            return "INPUT_HIGH";
        }
    }
}
