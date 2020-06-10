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
            Type[] allTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            Type baseIGate = typeof(PrototypeGate);

            foreach(Type type in allTypes)
            {
                Type next = type;
                Type previous = null;
     
                while (next != null && baseIGate.FullName != next.FullName)
                {
                    previous = next;
                    next = next.BaseType;
                }

                //Als de vorige niet null, niet abstract en niet een van de primitieve types is,
                //dan wordt deze tyoe toegevoegd aan de factory
                if (previous != null && !previous.IsAbstract && !previous.IsPrimitive)
                {
                    AddToFactory(type);
                }
            }
        }

        private void AddToFactory(Type type)
        {
            System.Reflection.MethodInfo[] methods = type.GetMethods();

            foreach (System.Reflection.MethodInfo method in methods)
            {
                if (method.Name == "GetKey")
                {
                    PrototypeGate instance = GetGateInstance(type);
                    this.FactoryList.Add(instance.GetKey(), instance);
                }
            }
        }

        private PrototypeGate GetGateInstance(Type type)
        {
            foreach(System.Reflection.ConstructorInfo constructor in type.GetConstructors())
            {
                if (constructor.GetParameters().Length == 0)
                {
                    return (PrototypeGate)constructor.Invoke(null);
                }
            }

            return default(PrototypeGate);
        }

        public static ComponentFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ComponentFactory();
            }

            return Instance;
        }

        Dictionary<string, PrototypeGate> FactoryList = new Dictionary<string, PrototypeGate>();

        //Voegt de gate toe aan de factorylist
        public void Assign(string name, PrototypeGate gate)
        {
            //Alse deze name nog niet bekend is, dan wordt die toegevoegd
            if (!FactoryList.ContainsKey(name))
            {
                FactoryList.Add(name, gate);
            }
        }

        //Clone een component
        public IGate CreateComponent(string type)
        {
            //Als dit type bekend is in de factorylist, dan wordt deze gecloned
            if (FactoryList.ContainsKey(type))
            {
                return FactoryList[type].Clone();
            }

            //Anders gebeurt er niks
            return null;
        }
    }
}
