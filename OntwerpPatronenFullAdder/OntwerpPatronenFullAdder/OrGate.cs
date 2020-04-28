using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class OrGate : SimpleGate
    {
        private List<IGate> inputGates;

        private OrGate(int id) : base(id)
        {

        }

        static SimpleGate CreateOrGate(int id)
        {
            return new OrGate(id);
        }

        public new bool GetState()
        {
            foreach (IGate gate in this.inputGates)
            {
                if (gate.GetState())
                {
                    return true;
                }
            }

            return false;
        }

        public new bool AddInput(IGate gate)
        {
            this.inputGates.Add(gate);
            return true;
        }
    }
}
