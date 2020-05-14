using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class OutputGate : SimpleGate
    {
        private bool state;
        private IGate inputGate;

        private static OutputGate Instance = new OutputGate("OUTPUT");

        private OutputGate(string id) : base(id)
        {
            state = false;
        }

        private OutputGate()
        {

        }

        public override bool AddInput(IGate gate)
        {
            inputGate = gate;
            return true;
        }

        public override bool GetState()
        {
            return state;
        }

        public override void UpdateState()
        {
            state = inputGate.GetState();
        }

        public override List<IGate> GetInputs()
        {
            List<IGate> inputGates = new List<IGate>();
            inputGates.Add(inputGate);
            return inputGates;
        }

        public override IGate Clone()
        {
            return new OutputGate();
        }
    }
}
