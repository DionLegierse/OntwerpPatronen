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

        //Returnt state low, 0
        public override bool GetState()
        {
            return false;
        }

        //Maakt een clone van de gate
        public override IGate Clone()
        {
            return new InputLowGate();
        }

        //Returnt de naam van de gate
        public override string GetKey()
        {
            return "INPUT_LOW";
        }
    }
}
