using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class ComponentFactory
    {
        private static ComponentFactory Instance;

        private ComponentFactory()
        {
            
        }

        public static ComponentFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ComponentFactory();
                PrototypeGate.Init();
            }

            return Instance;
        }

        Dictionary<string, PrototypeGate> FactoryList = new Dictionary<string, PrototypeGate>();

        public void Assign(string name, PrototypeGate gate)
        {
            if (!FactoryList.ContainsKey(name))
            {
                FactoryList.Add(name, gate);
            }
        }

        public IGate CreateComponent(string type)
        {
            if (FactoryList.ContainsKey(type))
            {
                return FactoryList[type].Clone();
            }

            return null;
        }
    }
}
