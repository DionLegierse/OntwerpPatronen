using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    class ComponentUpdater
    {
        #region SINGLETON PATTERN
        private static readonly ComponentUpdater instance = new ComponentUpdater();

        private readonly Dictionary<IGate, List<IGate>> updateTable = new Dictionary<IGate, List<IGate>>();

        static ComponentUpdater()
        {

        }

        private ComponentUpdater()
        {

        }

        public static ComponentUpdater GetInstance()
        {
            return instance;
        }

        #endregion


        //Voeg de componenten toe en de verbonden componenten
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

        //Update alle verbonden componenten
        public void UpdateConnectedComponents(IGate component)
        {

            List<IGate> updateList = updateTable[component];

            foreach (IGate gate in updateList)
            {
                gate.UpdateState();
            }
        }
    }
}
