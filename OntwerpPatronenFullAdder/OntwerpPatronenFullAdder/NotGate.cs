using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class NotGate : SimpleGate
    {
        private IGate inputGate = null;

        private NotGate(int id) : base(id)
        {

        }

        static SimpleGate CreateNotGate(int id)
        {
            return new NotGate(id);
        }

        public new bool GetState()
        {
            return !inputGate.GetState();
        }

        public new bool AddInput(IGate gate)
        {
            if (this.inputGate == null)
            {
                this.inputGate = gate;
                return true;
            }

            return false;
        }
    }
}
