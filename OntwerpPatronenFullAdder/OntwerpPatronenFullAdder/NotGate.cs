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
        private bool state;

        private NotGate(int id) : base(id)
        {

        }

        static SimpleGate CreateNotGate(int id)
        {
            return new NotGate(id);
        }

        public override bool GetState()
        {
            return state;
        }

        public override void UpdateState()
        {
            state = !inputGate.GetState();
            
            ComponentObserver.GetInstance().Notify(this);
        }

        public override bool AddInput(IGate gate)
        {
            if (this.inputGate == null)
            {
                this.inputGate = gate;
                return true;
            }

            return false;
        }

        public override List<IGate> GetInputs()
        {
            List<IGate> inputGates = new List<IGate>();
            inputGates.Add(inputGate);
            return inputGates;
        }
    }
}
