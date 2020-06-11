using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class AndGate : PrototypeGate
    {
        //Het minimale aantal gates
        private const int MINIMAL_GATES = 2;

        //Een lijst van input gates
        private List<IGate> inputGates = new List<IGate>();
        //De state van de outputgate
        bool state;

        public AndGate()
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
            state = true;
            foreach (IGate gate in this.inputGates)
            {
                //Als een van de inputgates false is, dan is de outputgate false
                if (!gate.GetState())
                {
                    state = false;
                }
            }

            ComponentObserver.GetInstance().Notify(this);
        }

        //Voeg een inputgate toe aan de node
        public override bool AddInput(IGate gate)
        {
            this.inputGates.Add(gate);
            return true;
        }

        //Returnt de lijst van inputgates
        public override List<IGate> GetInputs()
        {
            return inputGates;
        }

        //Maakt een clone van de andgate
        public override IGate Clone()
        {
            return new AndGate();
        }

        //Returnt de naam van de node
        public override string GetKey()
        {
            return "AND";
        }

        //Returnt false als er minder dan MINIMAL_GATES aan inputgates geconnect zijn
        public override bool IsConnectedCorrect()
        {
            return (inputGates.Count >= MINIMAL_GATES);
        }
    }
}
