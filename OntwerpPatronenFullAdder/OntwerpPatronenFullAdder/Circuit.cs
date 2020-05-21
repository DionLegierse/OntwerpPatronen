using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{

    public class Probe
    {
    }
    public class Circuit
    {
        private FileReader Reader;

        private readonly Dictionary<string, IGate>          Nodes       = new Dictionary<string, IGate>();
        private readonly Dictionary<string, List<IGate>>    Connections = new Dictionary<string, List<IGate>>();
        private readonly Dictionary<IGate, bool>            Inputs      = new Dictionary<IGate, bool>();

        public Circuit(string path)
        {
            Reader = new FileReader(path);

            Dictionary<string, string> entry;

            //Make all the components
            while ((entry = Reader.NextComponent()) != null)
            {
                foreach (KeyValuePair<string, string> node in entry)
                {
                    MakeComponent(node);
                }
            }

            //Make all the connections
            List<string> connection;
            while ((connection = Reader.NextConnection()) != null)
            {
                string nodeToAdd = connection[0];
                connection.RemoveAt(0);

                foreach (string component in connection)
                {
                    if (Nodes.ContainsKey(component) && Nodes.ContainsKey(nodeToAdd))
                    {
                        Nodes[component].AddInput(Nodes[nodeToAdd]);
                    }
                }
            }

            //Add components to observer
            foreach(KeyValuePair<string, IGate> node in Nodes)
            {
                ComponentObserver.GetInstance().AddComponent(node.Value);
            }
        }

        private void MakeComponent(KeyValuePair<string, string> node)
        {
            IGate component = ComponentFactory.GetInstance().CreateComponent(node.Value);

            if (node.Value.Contains("INPUT"))
            {
                component = ComponentFactory.GetInstance().CreateComponent("INPUT");
            }


            if (!Nodes.ContainsKey(node.Key) && component != null)
            {
                Nodes.Add(node.Key, component);
            }

            switch (node.Value)
            {
                case "INPUT_HIGH":
                    Inputs.Add(component, true);
                    break;
                case "INPUT_LOW":
                    Inputs.Add(component, false);
                    break;
                case "PROBE":
                    //TODO: add probes 
                    break;
            }
        }

        public void Simulate()
        {
            foreach(KeyValuePair<IGate, bool> input in Inputs)
            {
                if (input.Key is InputGate gate)
                {
                    gate.SetState(input.Value);
                }
            }
        }
    }
}
