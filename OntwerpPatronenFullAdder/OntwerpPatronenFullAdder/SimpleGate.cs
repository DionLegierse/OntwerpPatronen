﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class SimpleGate : IGate
    {
        public SimpleGate()
        {
            //Add to factory
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
