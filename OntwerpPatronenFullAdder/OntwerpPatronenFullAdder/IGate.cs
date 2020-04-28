using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    interface IGate
    {
        bool AddInput(IGate gate);
        bool GetState();
    }
}
