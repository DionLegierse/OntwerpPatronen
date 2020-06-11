using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class NotGate : PrototypeGate
    {
        private IGate inputGate = null;
        private bool state;

        public NotGate()
        {

        }

        public override bool GetState()
        {
            return state;
        }

        public override void UpdateState()
        {
            state = !inputGate.GetState();

            base.UpdateState();
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

        public override IGate Clone()
        {
            return new NotGate();
        }

        public override string GetKey()
        {
            return "NOT";
        }

        public override bool IsConnectedCorrect()
        {
            return (inputGate != null);
        }
    }
}
