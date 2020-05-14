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

        public Circuit(string path)
        {
            Reader = new FileReader(path);

            Dictionary<string, string> entry;

            while ((entry = Reader.NextComponent()) != null)
            {
                foreach (KeyValuePair<string, string> node in entry)
                {
                    IGate component = ComponentFactory.GetInstance().CreateComponent(node.Value);
                    
                    if (!Nodes.ContainsKey(node.Key))
                    {
                        Nodes.Add(node.Key, component);
                    }
                }
            }
        }



    }
}
