using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class SimpleGate : IGate
    {
        private int id;

        public SimpleGate(int id)
        {
            //Add to factory
            this.id = id;
        }
        public void SetInput(IGate gate)
        {

        }
        public bool GetState()
        {
            return false;
        }
        public void UpdateState()
        {

        }
    }
}
