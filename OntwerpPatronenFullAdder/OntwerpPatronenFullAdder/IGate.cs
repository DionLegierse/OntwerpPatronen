using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public interface IGate
    {
        bool AddInput(IGate gate);
        bool GetState();
        void UpdateState();
        List<IGate> GetInputs();
        IGate Clone();
        string GetKey();
    }
}
