using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputGate : PrototypeGate
    {
        public void UpdateState(bool state)
        {
            ComponentObserver.GetInstance().Notify(this);
        }

        public InputGate (string id) : base(id)
        {

        }

        public InputGate()
        {

        }
    }
}
