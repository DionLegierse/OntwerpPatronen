using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class InputGate : PrototypeGate
    {
        //Kijkt naar verandering in de state
        public override void UpdateState()
        {
            ComponentObserver.GetInstance().Notify(this);
        }

        public InputGate()
        {

        }

        //Als deze er is, dan is het al goed
        public override bool IsConnectedCorrect()
        {
            return true;
        }
    }
}
