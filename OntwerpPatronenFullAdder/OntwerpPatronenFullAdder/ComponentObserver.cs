using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class ComponentObserver
    {
        //Een instance van de observer
        private static readonly ComponentObserver instance = new ComponentObserver();

        //Een lijst met alle inputs van alle componenten
        private readonly Dictionary<IGate, List<IGate>> updateTable = new Dictionary<IGate, List<IGate>>();

        static ComponentObserver()
        {

        }

        private ComponentObserver()
        {

        }

        //Returnt de observer instance
        public static ComponentObserver GetInstance()
        {
            return instance;
        }

        //Voeg een component toe aan de observer
        public void AddComponent(IGate component)
        {
            List<IGate> inputs = component.GetInputs();

            foreach(IGate input in inputs)
            {
                //Als deze key nog niet bekend is in de updateTable, dan wordt deze toegevoegd
                if (!updateTable.ContainsKey(input))
                {
                    updateTable.Add(input, new List<IGate>());
                }

                //Voeg de component toe op de plek van de specifieke input
                updateTable[input].Add(component);
            }
        }

        public void Notify(IGate component)
        {
            //Krijg de List van IGates van dit specifieke component
            List<IGate> updateList = updateTable[component];

            //Update de state van alle gates in de updatelist
            foreach (IGate gate in updateList)
            {
                gate.UpdateState();
            }
        }
    }
}
