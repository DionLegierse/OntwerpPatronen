using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class OutputGate : SimpleGate
    {
        private bool state;
        private IGate input;

        public OutputGate(int id) : base(id)
        {
            state = false;
        }

        public override bool AddInput(IGate gate)
        {
            input = gate;
            return true;
        }

        public override bool GetState()
        {
            return input.GetState();
        }
    }
}
