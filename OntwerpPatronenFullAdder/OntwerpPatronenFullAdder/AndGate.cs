using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class AndGate : SimpleGate
    {
        private List<IGate> inputGates;

        private AndGate(int id) : base(id)
        {
            
        }

        static SimpleGate CreateAndGate(int id)
        {
            return new AndGate(id);
        }

        public new bool GetState()
        {
            foreach(IGate gate in this.inputGates)
            {
                if (!gate.GetState())
                {
                    return false;
                }
            }

            return true;
        }

        public new bool AddInput(IGate gate)
        {
            this.inputGates.Add(gate);
            return true;
        }
    }
}
