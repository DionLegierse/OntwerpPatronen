using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class InputGate : PrototypeGate
    {
        private bool state;

        private static InputGate Instance = new InputGate("Input");
        private InputGate(string id) : base(id)
        {
            state = false;
        }

        private InputGate()
        {

        }

        public void SetState(bool state)
        {
            this.state = state;
            ComponentObserver.GetInstance().Notify(this);
        }

        public override bool GetState()
        {
            return state;
        }

        public override IGate Clone()
        {
            return new InputGate();
        }
    }
}
