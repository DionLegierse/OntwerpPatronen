using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class OrGate : PrototypeGate
    {

        private readonly List<IGate> inputGates = new List<IGate>();
        private bool state;
        public OrGate()
        {

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

        public override IGate Clone()
        {
            return new OrGate();
        }
        public override string GetKey()
        {
            return "OR";
        }
    }
}
