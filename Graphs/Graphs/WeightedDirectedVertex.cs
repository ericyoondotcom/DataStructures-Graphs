using System;
using System.Collections.Generic;

using System.Linq;

namespace Graphs
{
	public class WeightedDirectedVertex<T>
	{
        public List<Tuple<WeightedDirectedVertex<T>, float>> edges;
		public T val;
        public WeightedDirectedVertex(T val, List<Tuple<WeightedDirectedVertex<T>, float>> neighbors = null)
		{
			if (neighbors == null)
			{
                List<(string Name, int Age)> list = new List<(string, int)>();
                var data = list.Where(t => t.Age > 3);
                                                                  
                //(string test, int bla) value1 = ("", 3);
                //data.RemoveAt(data.FindIndex(x => x.firstVal == "what youre looking for"))

                this.edges = new List<Tuple<WeightedDirectedVertex<T>, float>>();
			}
			else
			{
                this.edges = neighbors;
			}
			this.val = val;
		}
	}
}
