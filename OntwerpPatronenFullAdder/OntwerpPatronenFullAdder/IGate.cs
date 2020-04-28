using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    interface IGate
    {
        void SetInput(IGate gate);
        bool GetState();
        void UpdateState();
    }
}
