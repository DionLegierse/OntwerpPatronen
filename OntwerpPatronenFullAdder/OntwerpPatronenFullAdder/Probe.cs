using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class Probe : PrototypeGate
    {
        //De input van de gate
        private IGate ProbeGate = null;
        //De state van de outputgate
        private bool state = false;

        public Probe()
        {

        }

        //Voeg een gate toe aan de node
        public override bool AddInput(IGate gate)
        {
            //Kan alleen toevegen als er nog geen gate is, aangezien er maar 1 input gate kan zijn
            if (this.ProbeGate == null)
            {
                this.ProbeGate = gate;
                return true;
            }

            return false;
        }

        //Maakt een clone van de gate
        public override IGate Clone()
        {
            return new Probe();
        }

        //Returnt een lijst met de inputgate
        public override List<IGate> GetInputs()
        {
            List<IGate> inputGates = new List<IGate>();
            inputGates.Add(ProbeGate);
            return inputGates;
        }

        //Returnt de state van de outputgate
        public override bool GetState()
        {
            return state;
        }

        //Update de state van de outputgate
        public override void UpdateState()
        {
            //State is gelijk aan de input
            state = ProbeGate.GetState();
        }

        //Returnt de name van de gate
        public override string GetKey()
        {
            return "PROBE";
        }

        //Return false als er geen input gate aan vast zit
        public override bool IsConnectedCorrect()
        {
            return (ProbeGate != null);
        }
    }
}
