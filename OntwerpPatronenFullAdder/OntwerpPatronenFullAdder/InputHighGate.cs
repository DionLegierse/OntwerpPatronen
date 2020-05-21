using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputHighGate : InputGate
    {
        private static InputHighGate Instance;

        public static void Initialize()
        {
            Instance = new InputHighGate("INPUT_HIGH");
        }

        private InputHighGate(string id) : base(id)
        {
        }

        private InputHighGate()
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
    }
}
