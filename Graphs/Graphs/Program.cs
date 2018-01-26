using System;
using System.Collections.Generic;

namespace Graphs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*

            Console.WriteLine("Hello World!");

            SimpleGraph<string> myGraph = new SimpleGraph<string>();

            var territories = new Dictionary<string, SimpleVertex<string>>();

            #region Risk Game
            //https://upload.wikimedia.org/wikipedia/commons/a/aa/Risk_game_map_fixed.png
            for (int i = 1; i <= 9; i++)
            {
                string name = "NA" + i.ToString();
                territories.Add(name, myGraph.AddVertex(name));
            }
            for (int i = 1; i <= 4; i++)
            {
                string name = "SA" + i.ToString();
                territories.Add(name, myGraph.AddVertex(name));
            }
            for (int i = 1; i <= 6; i++)
            {
                string name = "AF" + i.ToString();
                territories.Add(name, myGraph.AddVertex(name));
            }
            for (int i = 1; i <= 7; i++)
            {
                string name = "EU" + i.ToString();
                territories.Add(name, myGraph.AddVertex(name));
            }
            for (int i = 1; i <= 12; i++)
            {
                string name = "AS" + i.ToString();
                territories.Add(name, myGraph.AddVertex(name));
            }
            for (int i = 1; i <= 4; i++)
            {
                string name = "AU" + i.ToString();
                territories.Add(name, myGraph.AddVertex(name));
            }

            myGraph.AddEdge(territories["NA1"], territories["NA6"]);
            myGraph.AddEdge(territories["NA1"], territories["NA2"]);
            myGraph.AddEdge(territories["NA2"], territories["NA6"]);
            myGraph.AddEdge(territories["NA2"], territories["NA7"]);
            myGraph.AddEdge(territories["NA2"], territories["NA9"]);
            myGraph.AddEdge(territories["NA3"], territories["NA9"]);
            myGraph.AddEdge(territories["NA3"], territories["NA4"]);
            myGraph.AddEdge(territories["NA4"], territories["NA9"]);
            myGraph.AddEdge(territories["NA4"], territories["NA7"]);
            myGraph.AddEdge(territories["NA4"], territories["NA8"]);
            myGraph.AddEdge(territories["NA5"], territories["NA6"]);
            myGraph.AddEdge(territories["NA5"], territories["NA7"]);
            myGraph.AddEdge(territories["NA5"], territories["NA8"]);
            myGraph.AddEdge(territories["NA6"], territories["NA7"]);
            myGraph.AddEdge(territories["NA7"], territories["NA9"]);
            myGraph.AddEdge(territories["NA7"], territories["NA8"]);

            myGraph.AddEdge(territories["SA1"], territories["SA2"]);
            myGraph.AddEdge(territories["SA1"], territories["SA3"]);
            myGraph.AddEdge(territories["SA2"], territories["SA3"]);
            myGraph.AddEdge(territories["SA2"], territories["SA4"]);
            myGraph.AddEdge(territories["SA3"], territories["SA4"]);

            myGraph.AddEdge(territories["AU1"], territories["AU3"]);
            myGraph.AddEdge(territories["AU1"], territories["AU4"]);
            myGraph.AddEdge(territories["AU2"], territories["AU3"]);
            myGraph.AddEdge(territories["AU2"], territories["AU4"]);
            myGraph.AddEdge(territories["AU3"], territories["AU4"]);

            myGraph.AddEdge(territories["EU1"], territories["EU2"]);
            myGraph.AddEdge(territories["EU1"], territories["EU3"]);
            myGraph.AddEdge(territories["EU1"], territories["EU4"]);
            myGraph.AddEdge(territories["EU1"], territories["EU7"]);
            myGraph.AddEdge(territories["EU2"], territories["EU4"]);
            myGraph.AddEdge(territories["EU3"], territories["EU4"]);
            myGraph.AddEdge(territories["EU3"], territories["EU5"]);
            myGraph.AddEdge(territories["EU3"], territories["EU6"]);
            myGraph.AddEdge(territories["EU3"], territories["EU7"]);
            myGraph.AddEdge(territories["EU4"], territories["EU6"]);
            myGraph.AddEdge(territories["EU5"], territories["EU6"]);
            myGraph.AddEdge(territories["EU5"], territories["EU7"]);

            myGraph.AddEdge(territories["AF1"], territories["AF2"]);
            myGraph.AddEdge(territories["AF1"], territories["AF5"]);
            myGraph.AddEdge(territories["AF1"], territories["AF6"]);
            myGraph.AddEdge(territories["AF2"], territories["AF3"]);
            myGraph.AddEdge(territories["AF2"], territories["AF4"]);
            myGraph.AddEdge(territories["AF2"], territories["AF5"]);
            myGraph.AddEdge(territories["AF2"], territories["AF6"]);
            myGraph.AddEdge(territories["AF3"], territories["AF5"]);
            myGraph.AddEdge(territories["AF4"], territories["AF6"]);

            myGraph.AddEdge(territories["AS1"], territories["AS2"]);
            myGraph.AddEdge(territories["AS1"], territories["AS3"]);
            myGraph.AddEdge(territories["AS1"], territories["AS7"]);
            myGraph.AddEdge(territories["AS1"], territories["AS11"]);
            myGraph.AddEdge(territories["AS2"], territories["AS3"]);
            myGraph.AddEdge(territories["AS2"], territories["AS8"]);
            myGraph.AddEdge(territories["AS2"], territories["AS9"]);
            myGraph.AddEdge(territories["AS2"], territories["AS10"]);
            myGraph.AddEdge(territories["AS2"], territories["AS11"]);
            myGraph.AddEdge(territories["AS3"], territories["AS7"]);
            myGraph.AddEdge(territories["AS3"], territories["AS9"]);
            myGraph.AddEdge(territories["AS4"], territories["AS6"]);
            myGraph.AddEdge(territories["AS4"], territories["AS8"]);
            myGraph.AddEdge(territories["AS4"], territories["AS10"]);
            myGraph.AddEdge(territories["AS4"], territories["AS12"]);
            myGraph.AddEdge(territories["AS5"], territories["AS6"]);
            myGraph.AddEdge(territories["AS5"], territories["AS8"]);
            myGraph.AddEdge(territories["AS6"], territories["AS8"]);
            myGraph.AddEdge(territories["AS6"], territories["AS12"]);
            myGraph.AddEdge(territories["AS8"], territories["AS10"]);
            myGraph.AddEdge(territories["AS10"], territories["AS11"]);
            myGraph.AddEdge(territories["AS10"], territories["AS12"]);

            //Cross-continental. ORDER: NA, SA, AU, AF, EU, AS
            myGraph.AddEdge(territories["NA1"], territories["EU6"]);
            myGraph.AddEdge(territories["NA3"], territories["SA4"]);
            myGraph.AddEdge(territories["NA5"], territories["EU2"]);

            myGraph.AddEdge(territories["SA2"], territories["AF5"]);

            myGraph.AddEdge(territories["AU2"], territories["AS9"]);

            myGraph.AddEdge(territories["AF2"], territories["AS7"]);
            myGraph.AddEdge(territories["AF3"], territories["EU5"]);
            myGraph.AddEdge(territories["AF3"], territories["AS7"]);
            myGraph.AddEdge(territories["AF5"], territories["EU5"]);
            myGraph.AddEdge(territories["AF5"], territories["EU7"]);

            myGraph.AddEdge(territories["EU5"], territories["AS7"]);
            myGraph.AddEdge(territories["EU6"], territories["AS7"]);
            myGraph.AddEdge(territories["EU6"], territories["AS1"]);
            myGraph.AddEdge(territories["EU6"], territories["AS11"]);


            #endregion
            */

            var g = new WeightedDirectedGraph<int>();

            var one = g.AddVertex(1);
            var two = g.AddVertex(2);
            var three = g.AddVertex(3);
            var four = g.AddVertex(4);
            var five = g.AddVertex(5);
            var scarynode = g.AddVertex(10);

            g.AddEdge(one, two, 1);
			g.AddEdge(two, three, 62);
            g.AddEdge(two, scarynode, 0);
            g.AddEdge(scarynode, one, 1);
			g.AddEdge(three, one, 1);
			g.AddEdge(five, three, 1);
			g.AddEdge(five, two, 1);
			g.AddEdge(four, two, 1);
            g.AddEdge(three, five, 1);
            g.AddEdge(five, four, 1);
            Console.WriteLine(g.DepthFirstTraversal(one, 4).val);
            		
        }
    }
}