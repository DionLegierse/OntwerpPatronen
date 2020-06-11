using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class NotGate : PrototypeGate
    {
        //De input van de gate
        private IGate inputGate = null;
        //De state van de outputgate
        private bool state;

        public NotGate()
        {

        }

        //Returnt de state van de outputgate
        public override bool GetState()
        {
            return state;
        }

        //Update de state van de outputgate
        public override void UpdateState()
        {
            //output state is omgekeerde inputstate
            state = !inputGate.GetState();

            base.UpdateState();
        }

        //Voeg een gate toe aan de node
        public override bool AddInput(IGate gate)
        {
            //Kan alleen toevegen als er nog geen gate is, aangezien er maar 1 input gate kan zijn
            if (this.inputGate == null)
            {
                this.inputGate = gate;
                return true;
            }

            return false;
        }

        //Returnt een lijst met de inputgate
        public override List<IGate> GetInputs()
        {
            List<IGate> inputGates = new List<IGate>();
            inputGates.Add(inputGate);
            return inputGates;
        }

        //Maakt een clone van de gate
        public override IGate Clone()
        {
            return new NotGate();
        }

        //Returnt de name van de gate
        public override string GetKey()
        {
            return "NOT";
        }

        //Return false als er geen input gate aan vast zit
        public override bool IsConnectedCorrect()
        {
            return (inputGate != null);
        }
    }
}
