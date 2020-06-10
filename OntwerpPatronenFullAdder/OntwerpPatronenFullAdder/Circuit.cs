using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntwerpPatronenFullAdder
{
    public class Circuit
    {
        //Een filereader om de meegegeven file te kunnen lezen
        private FileReader Reader;

        //Een dictionary waarin alle nodes worden opgeslagen
        private readonly Dictionary<string, IGate>  Nodes       = new Dictionary<string, IGate>();
        //Een lijst waarin alle inputs worden gezet
        private readonly List<InputGate>            Inputs      = new List<InputGate>();
        //Een dictionary waarin alle probes/outputs worden gezet
        private readonly Dictionary<string, Probe>  Probes      = new Dictionary<string, Probe>();

        //Een bool om te checken of het hele circuit in elkaar zin en gesimuleerd kan worden
        private bool isSimulateable = false;

        //Constructor met de path naar de inputfile
        public Circuit(string path)
        {
            //Maak de nieuwe filereader
            Reader = new FileReader(path);

            //Een dictionary voor alle entry's
            Dictionary<string, string> entry;

            //Maak alle components
            while ((entry = Reader.NextComponent()) != null)
            {
                foreach (KeyValuePair<string, string> node in entry)
                {
                    MakeComponent(node);
                }
            }

            //Maak alle connecties
            List<string> connection;
            while ((connection = Reader.NextConnection()) != null)
            {
                //In connection[0] staat de node waar de connecties aan worden toegevoegd
                string nodeToAdd = connection[0];
                connection.RemoveAt(0);

                foreach (string component in connection)
                {
                    //Als bijde nodes bekend zijn dan wordt de connectie gemaakt
                    if (Nodes.ContainsKey(component) && Nodes.ContainsKey(nodeToAdd))
                    {
                        //Voeg de output van de juste node toe aan de input van de juiste node
                        Nodes[component].AddInput(Nodes[nodeToAdd]);
                    }
                }
            }

            //Add components to observer, check for loops and check for connections
            foreach(KeyValuePair<string, IGate> node in Nodes)
            {
                //Als er een loop is, of als een input niet geconnect is, dan kan de simulatie niet gedaan worden
                if (IsComponentLoop(node.Value) || !node.Value.IsConnectedCorrect())
                {
                    return;
                }

                ComponentObserver.GetInstance().AddComponent(node.Value);
            }

            //Als alles goed is gegaan, dan is de simulatie uitvoerbaar
            isSimulateable = true;
        }

        //Check of er een loop in zit
        private bool IsComponentLoop(IGate toCheck)
        {
            //Een lijst van nodes die al gecheked zijn
            List<IGate> checkedNodes = new List<IGate>();
            //De inputs van de nodes die gechecked moeten worden
            Stack<IGate> toCheckStack = new Stack<IGate>(toCheck.GetInputs());

            //Zolang er inputs zijn die gechecked moeten worden
            while (toCheckStack.Count() > 0)
            {
                //Krijg de eerstvolgende input
                IGate current = toCheckStack.Pop();
                checkedNodes.Add(current);
                
                //Als er een loop is, return true
                if (current.GetInputs().Contains(toCheck)) return true;

                foreach (IGate n in current.GetInputs())
                {
                    if (!checkedNodes.Contains(n))
                    {
                        toCheckStack.Push(n);
                    }
                }
            }

            //Alles is goed
            return false;
        }

        //Maak een component aan
        private void MakeComponent(KeyValuePair<string, string> node)
        {
            //Creëer het component van het juiste type
            IGate component = ComponentFactory.GetInstance().CreateComponent(node.Value);

            //Als deze node nog niet is toegevoegd en als component niet null is,
            //dan wordt deze node toegevoegd
            if (!Nodes.ContainsKey(node.Key) && component != null)
            {
                Nodes.Add(node.Key, component);
            }

            //Als de component een input gate is, dan wordt deze toegevoegd aan de inputs
            if(component is InputGate input)
            {
                Inputs.Add(input);
            }

            //Als de component een output gate is, dan wordt deze toegevoegd aan de outputs
            if (component is Probe probe)
            {
                Probes.Add(node.Key, probe);
            }
        }

        //Hier wordt het hele circuit gesimuleerd
        public void Simulate()
        {
            if (!isSimulateable)
            {
                Console.WriteLine("Error: circuit cannot be simulated, check circuit for errors");
                return;
            }

            //Update alle outputs van de nodes
            foreach (InputGate input in Inputs)
            {
                input.UpdateState();
            }
       
            Console.WriteLine("Output for all probe nodes:");

            //Print alle probes
            foreach (KeyValuePair<string, Probe> probe in Probes)
            {
                Console.WriteLine("\tProbe '" + probe.Key + "'\t" + (probe.Value.GetState() ? 1 : 0));
            }

            Console.WriteLine("...bye");
        }
    }
}
