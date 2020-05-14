using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class OrGate : SimpleGate
    {
        private readonly List<IGate> inputGates = new List<IGate>();
        private bool state;

        private OrGate(int id) : base(id)
        {

        }

        static SimpleGate CreateOrGate(int id)
        {
            return new OrGate(id);
        }

        public override bool GetState()
        {
            return state;
        }

        public override void UpdateState()
        {
            state = false;
            foreach (IGate gate in this.inputGates)
            {
                if (gate.GetState())
                {
                    state = true;
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
