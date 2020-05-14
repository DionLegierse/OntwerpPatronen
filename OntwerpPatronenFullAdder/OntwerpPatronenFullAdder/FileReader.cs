using System;
using System.IO;
using System.Collections.Generic;

namespace OntwerpPatronenFullAdder
{
    class FileReader
    {
        public FileReader(string path)
        {
            FileIndex = 0;
            ComponentsFound = false;
            beginFound = false;
            StrFile = File.ReadAllLines(path);
        }

        public Dictionary<string, string> NextComponent()
        {
            //Voor de gates met de values, string 1 = nodenaam en string 2 = poortnaam
            var Nodes = new Dictionary<string, string>();
            //Voor tussentijdse opslag van nodenaam
            string NodeName = "";
            //Voor tussentijdse opslag van poortnaam
            string StrGate = "";
            //De file wordt line voor line uitgelezen
            string line = StrFile[FileIndex];
            
            //Zolang er geen lege regel of # is gevonden door blijven gaan
            if (!this.ComponentsFound && line.Length != 0)
            {
                //Langs de eerste comment regels met een # gaan
                while (!this.beginFound)
                {
                    if (line[0] != '#')
                    {
                        beginFound = true;
                    }
                    else
                    {
                        FileIndex++;
                        line = StrFile[FileIndex];
                    }
                }

                {
                    //Om door de regel heen te gaan
                    int lineIndex = 0;
                    //Voor de : staat de naam van de node
                    while (line[lineIndex] != ':')
                    {
                        NodeName += line[lineIndex++];
                    }

                    //Anders gaat de : mee
                    lineIndex++;

                    //De regel eindigt altijd met een ; daar voor staat de naam van de gate
                    while (line[lineIndex] != ';')
                    {
                        //Spaties en tabs hoeven niet mee in de gate naam
                        if (line[lineIndex] != ' ' && line[lineIndex] != 0x9)
                        {
                            StrGate += line[lineIndex];
                        }
                        lineIndex++;
                    }
                }

                //Voeg node naam en gate naam samen om terug te geven
                Nodes.Add(NodeName, StrGate);

                //debug shit
                Console.Write(NodeName);
                Console.Write(" ");
                Console.Write(StrGate);
                Console.Write("\n");
            }
            else
            {
                //Alle componenten zijn gevonden
                ComponentsFound = true;
                //We zijn weer terug bij een comment sectie, dus het begin van de connections moet gevonden worden
                beginFound = false;
                FileIndex++;
                //De code dat er geen meer komen
                return null;
            }

            FileIndex++;

            //Node naam en gate naam worden teruggegeven
            return Nodes;
        }

        public List<string> NextConnection()
        {
            List<string> connections = new List<string>();
            string connName = "";
            string line;

            if (FileIndex != StrFile.Length)
            {
                line = StrFile[FileIndex];
            }
            else
            {
                return null;
            }

            if (this.ComponentsFound)
            {
                //Langs de eerste comment regels met een # gaan
                while (!this.beginFound)
                {
                    if (line[0] != '#')
                    {
                        beginFound = true;
                    }
                    else
                    {
                        FileIndex++;
                        line = StrFile[FileIndex];
                    }
                }

                int lineIndex = 0;
                do
                {
                    if (line[lineIndex] == ':' || line[lineIndex] == ',' || line[lineIndex] == ';')
                    {
                        Console.Write(connName);
                        Console.Write(" ");
                        connections.Add(connName);
                        connName = "";
                    }
                    else if (line[lineIndex] != ' ' && line[lineIndex] != 0x9)
                    {
                        connName += line[lineIndex];
                    }
                    lineIndex++;
                } while (line[lineIndex-1] != ';');
                Console.Write("\n");
                
            }
            else
            {
                //More components to be found!!
                return null;
                //TODO: 'Error code' because not all components were found yet
            }

            FileIndex++;

            return connections;

        }

        //private variables
        //Hier wordt de file line voor line in opgeslagen
        private string[] StrFile;
        //Index voor de momenteel gebruikte line
        private int FileIndex;
        //Bools om aan te geven dat alle componenten zijn gevonden (ComponentsFound) en dat de comment sectie voorbij is (beginFound)
        private bool ComponentsFound, beginFound;
    }
}
