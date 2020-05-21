using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class ComponentObserver
    {
        private static readonly ComponentObserver instance = new ComponentObserver();

        private readonly Dictionary<IGate, List<IGate>> updateTable = new Dictionary<IGate, List<IGate>>();

        static ComponentObserver()
        {

        }

        private ComponentObserver()
        {

        }

        public static ComponentObserver GetInstance()
        {
            return instance;
        }

        public void AddComponent(IGate component)
        {
            List<IGate> inputs = component.GetInputs();

            foreach(IGate input in inputs)
            {
                if (!updateTable.ContainsKey(input))
                {
                    updateTable.Add(input, new List<IGate>());
                }

                updateTable[input].Add(component);
            }
        }

        public void Notify(IGate component)
        {

            List<IGate> updateList = updateTable[component];

            foreach (IGate gate in updateList)
            {
                gate.UpdateState();
            }
        }
    }
}
