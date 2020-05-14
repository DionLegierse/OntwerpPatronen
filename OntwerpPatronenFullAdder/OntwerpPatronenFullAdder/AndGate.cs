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
            this.inputGates = new List<IGate>();
        }

        static SimpleGate CreateAndGate(int id)
        {
            return new AndGate(id);
        }

        public override bool GetState()
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

        public override bool AddInput(IGate gate)
        {
            this.inputGates.Add(gate);
            return true;
        }
    }
}
