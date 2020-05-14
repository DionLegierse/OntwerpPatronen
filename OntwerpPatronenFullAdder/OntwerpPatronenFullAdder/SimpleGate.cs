using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder { 
public class SimpleGate : IGate
    {
        public SimpleGate(string id)
        {
            ComponentFactory.GetInstance().Assign(id, this);  
        }

        public SimpleGate()
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
    }
}
