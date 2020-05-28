using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class Circuit
    {
        private FileReader Reader;

        private readonly Dictionary<string, IGate>  Nodes       = new Dictionary<string, IGate>();
        private readonly List<InputGate>            Inputs      = new List<InputGate>();
        private readonly Dictionary<string, Probe>  Probes      = new Dictionary<string, Probe>();

        private bool isSimulateable = false;

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

            //Add components to observer, check for loops and check for connections
            foreach(KeyValuePair<string, IGate> node in Nodes)
            {
                if (IsComponentLoop(node.Value) || !node.Value.IsConnectedCorrect())
                {
                    return;
                }

                ComponentObserver.GetInstance().AddComponent(node.Value);
            }

            isSimulateable = true;
        }

        private bool IsComponentLoop(IGate toCheck)
        {
            List<IGate> checkedNodes = new List<IGate>();
            Stack<IGate> toCheckStack = new Stack<IGate>(toCheck.GetInputs());

            while (toCheckStack.Count() > 0)
            {
                IGate current = toCheckStack.Pop();
                checkedNodes.Add(current);

                if (current.GetInputs().Contains(toCheck)) return true;

                foreach (IGate n in current.GetInputs())
                {
                    if (!checkedNodes.Contains(n))
                    {
                        toCheckStack.Push(n);
                    }
                }
            }

            return false;
        }

        private void MakeComponent(KeyValuePair<string, string> node)
        {
            IGate component = ComponentFactory.GetInstance().CreateComponent(node.Value);

            if (!Nodes.ContainsKey(node.Key) && component != null)
            {
                Nodes.Add(node.Key, component);
            }

            if(component is InputGate input)
            {
                Inputs.Add(input);
            }

            if(component is Probe probe)
            {
                Probes.Add(node.Key, probe);
            }
        }

        public void Simulate()
        {
            if (!isSimulateable)
            {
                Console.WriteLine("Error: circuit cannot be simulated, check circuit for errors");
                return;
            }

            foreach (InputGate input in Inputs)
            {
                input.UpdateState();
            }
       
            Console.WriteLine("Output for all probe nodes:");

            foreach (KeyValuePair<string, Probe> probe in Probes)
            {
                Console.WriteLine("\tProbe '" + probe.Key + "'\t" + (probe.Value.GetState() ? 1 : 0));
            }

            Console.WriteLine("...bye");
        }
    }
}
