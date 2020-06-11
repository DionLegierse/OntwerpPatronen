using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder { 

    //De prototype voor alle soorten gates
    public abstract class PrototypeGate : IGate
    {
        ComponentUpdater updater = ComponentUpdater.GetInstance();

        public PrototypeGate()
        {

        }
        
        //Voeg een input toe aan een specifieke gate
        public virtual bool AddInput(IGate gate)
        {
            return false;
        }

        //Vraag de state op van een specifieke gate
        public virtual bool GetState()
        {
            return false;
        }

        //Kijk naar de verandering van de state
        public virtual void UpdateState()
        {
            if (updater != null)
            {
                updater.UpdateConnectedComponents(this);
            }
        }

        //Clone een specifieke gate
        public virtual IGate Clone()
        {
            return this;
        }

        //Returnt de lijst van inputs van een gate
        public virtual List<IGate> GetInputs()
        {
            List<IGate> inputList = new List<IGate>();
            return inputList;
        }

        //Returnt de naam van de gate
        public virtual string GetKey()
        {
            return "PROTOTYPE";
        }

        //Altijd false, want deze gate wordt niet toegevoegd aan het circuit
        public virtual bool IsConnectedCorrect()
        {
            return false;
        } 
    }
}
