using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class AndGate : SimpleGate
    {
        private List<IGate> inputGates = new List<IGate>();
        bool state;

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
            return state;
        }

        public override void UpdateState()
        {
            state = true;
            foreach (IGate gate in this.inputGates)
            {
                if (!gate.GetState())
                {
                    state = false;
                }
            }

            ComponentObserver.GetInstance().Notify(this);
        }

        public override bool AddInput(IGate gate)
        {
            this.inputGates.Add(gate);
            return true;
        }

        public override List<IGate> GetInputs()
        {
            return inputGates;
        }
    }
}
