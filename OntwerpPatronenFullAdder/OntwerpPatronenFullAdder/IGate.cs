using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    //De interface voor alle gates
    public interface IGate
    {
        //Voeg een input toe aan een specifieke gate
        bool AddInput(IGate gate);
        //Vraag de state van de output van een gate op
        bool GetState();
        //Update de state van de output van een gate
        void UpdateState();
        //Returnt de inputs van een gate
        List<IGate> GetInputs();
        //Clone een specifieke gate
        IGate Clone();
        //Vraag de naam van een gate op
        string GetKey();
        //Check of de gate correct is aangesloten
        bool IsConnectedCorrect();
    }
}
