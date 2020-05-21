using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class Probe : PrototypeGate
    {
        private IGate ProbeGate = null;
        private bool state = false;

        private static Probe Instance; 
        public static void Initialize()
        {
            Instance = new Probe("PROBE");
        }

        private Probe(string id) : base(id)
        {

        }

        private Probe()
        {

        }

        public override bool AddInput(IGate gate)
        {
            if (this.ProbeGate == null)
            {
                this.ProbeGate = gate;
                return true;
            }

            return false;
        }

        public override IGate Clone()
        {
            return new Probe();
        }

        public override List<IGate> GetInputs()
        {
            List<IGate> inputGates = new List<IGate>();
            inputGates.Add(ProbeGate);
            return inputGates;
        }

        public override bool GetState()
        {
            return state;
        }

        public override void UpdateState()
        {
            state = ProbeGate.GetState();
        }
       
    }
}
