﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class ComponentFactory
    {
        private static readonly ComponentFactory Instance = new ComponentFactory();

        private ComponentFactory()
        {

        }

        public static ComponentFactory GetInstance()
        {
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