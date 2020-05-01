using System;
using System.IO;
using System.Collections.Generic;

namespace OntwerpPatronenFullAdder
{
    internal partial class FileReader
    {
        public FileReader()
        {
            StrFile = File.ReadAllLines(FileLocation);
            FileIndex = 0;
            ComponentsFound = false;
            beginFound = false;
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
            if (!ComponentsFound && line.Length != 0)
            {
                //Langs de eerste comment regels met een # gaan
                while (!beginFound)
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

                //Om door de regel heen te gaan
                int lineIndex = 0;
                //Voor de : staat de naam van de node
                while (line[lineIndex] != ':')
                {
                    NodeName += line[lineIndex++];
                }

                //Anders gaan de : mee
                lineIndex++;

                //De regel eindigt altijd met een ; daar voor staat de naam van de gate
                while (line[lineIndex] != ';')
                {
                    //Spaties, tabs en eventuele \r en \n hoeven niet mee in de gate naam
                    if (line[lineIndex] != ' ' && line[lineIndex] != 0x9 && line[lineIndex] != '\n' && line[lineIndex] != '\r')
                    {
                        StrGate += line[lineIndex];
                    }
                    lineIndex++;
                }

                //Voeg node naam en gate naam samen om terug te geven
                Nodes.Add(NodeName, StrGate);

                //debug shit
                //Console.Write(NodeName);
                //Console.Write(" ");
                //Console.Write(StrGate);
                //Console.Write("\n");
            }
            else
            {
                //Alle componenten zijn gevonden
                ComponentsFound = true;
                //We zijn weer terug bij een comment sectie, dus het begin van de connections moet gevonden worden
                beginFound = false;
                //De code dat er geen meer komen
                Nodes.Add("Last", "0");
                //Console.Write("aaaaaaaaaaaaaa");
            }

            //Naar de volgende regel
            FileIndex++;

            //Node naam en gate naam worden teruggegeven
            return Nodes;
        }

        public void NextConnection()
        {
            if(ComponentsFound)
            {
                //Go on!
                //TODO: Add code to read the connection and find a good way to send them
            }
            else
            {
                //More components to be found!!
                //TODO: 'Error code' because not all components were found yet
            }
        }

        //private variables
        //De path naar de inputfile
        private static readonly string FileLocation = "C:\\Users\\Marleen\\inputFile.txt";
        //Hier wordt de file line voor line in opgeslagen
        private string[] StrFile;
        //Index voor de momenteel gebruikte line
        private int FileIndex;
        //Bools om aan te geven dat alle componenten zijn gevonden (ComponentsFound) en dat de comment sectie voorbij is (beginFound)
        private bool ComponentsFound, beginFound;
    }
}
