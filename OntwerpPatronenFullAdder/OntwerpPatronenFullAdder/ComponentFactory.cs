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
