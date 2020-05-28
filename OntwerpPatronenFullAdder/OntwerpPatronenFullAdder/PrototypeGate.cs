using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder { 
public abstract class PrototypeGate : IGate
    {
        public PrototypeGate()
        {

        }
            
        public virtual bool AddInput(IGate gate)
        {
            return false;
        }
        public virtual bool GetState()
        {
            return false;
        }

        public virtual void UpdateState()
        {
            ComponentObserver.GetInstance().Notify(this);
        }

        public virtual IGate Clone()
        {
            return this;
        }

        public virtual List<IGate> GetInputs()
        {
            List<IGate> inputList = new List<IGate>();
            return inputList;
        }

        public virtual string GetKey()
        {
            return "PROTOTYPE";
        }

        public virtual bool IsConnectedCorrect()
        {
            return false;
        } 
    }
}
