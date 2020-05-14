using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class InputGate : SimpleGate
    {
        private bool state;
        public InputGate(int id) : base(id)
        {
            state = false;
        }

        public void SetState(bool state)
        {
            this.state = state;
        }

        public override bool GetState()
        {
            return this.state;
        }
    }
}
