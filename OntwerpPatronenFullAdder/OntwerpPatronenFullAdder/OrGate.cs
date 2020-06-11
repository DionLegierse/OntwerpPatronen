using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class OrGate : PrototypeGate
    {
        //Het minimale aantal gates
        private const int MINIMAL_GATES = 2;

        //Een lijst van input gates
        private readonly List<IGate> inputGates = new List<IGate>();
        //De state van de outputgate
        private bool state;
        
        public OrGate()
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
            state = false;
            foreach (IGate gate in this.inputGates)
            {
                //Als 1 van de inputgates true is, dan is de outputgate true
                if (gate.GetState())
                {
                    state = true;
                }
            }

            base.UpdateState();
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

        //Maakt een clone van de orgate
        public override IGate Clone()
        {
            return new OrGate();
        }

        //Returnt de naam van de node
        public override string GetKey()
        {
            return "OR";
        }

        //Returnt false als er minder dan MINIMAL_GATES aan inputgates geconnect zijn
        public override bool IsConnectedCorrect()
        {
            return (inputGates.Count >= MINIMAL_GATES);
        }
    }
}
