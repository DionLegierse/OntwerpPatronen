using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputLowGate : InputGate
    {
        private static InputLowGate Instance;

        public static void Initialize()
        {
            Instance = new InputLowGate("INPUT_LOW");
        }

        private InputLowGate(string id) : base(id)
        {
        }

        private InputLowGate()
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
    }
}
