using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
	public class WeightedDirectedGraph<T> where T : IComparable
	{
        public List<WeightedDirectedVertex<T>> vertices;

        public WeightedDirectedGraph()
		{
            vertices = new List<WeightedDirectedVertex<T>>();
		}
        public WeightedDirectedGraph(List<WeightedDirectedVertex<T>> vertices)
		{
			this.vertices = vertices;
		}

        public void AddEdge(WeightedDirectedVertex<T> fromNode, WeightedDirectedVertex<T> toNode, float weight)
		{
            WeightedDirectedVertex<T> aVertex = vertices.Find(i => i == fromNode);
            WeightedDirectedVertex<T> bVertex = vertices.Find(i => i == toNode);
            aVertex.edges.Add(new Tuple<WeightedDirectedVertex<T>, float>(bVertex, weight));

		}

        public WeightedDirectedVertex<T> AddVertex(T newValue) => AddVertex(new WeightedDirectedVertex<T>(newValue));

        public WeightedDirectedVertex<T> AddVertex(WeightedDirectedVertex<T> newVertex)
		{
			vertices.Add(newVertex);
			foreach (WeightedDirectedVertex<T> i in vertices)
			{
				if (i == newVertex)
				{
					return i;
				}
			}
			throw new Exception("Can't find the newly added Vertex!");
		}

		public void RemoveVertex(WeightedDirectedVertex<T> vertex)
		{

            foreach (WeightedDirectedVertex<T> vtx in vertices)
			{
                vtx.edges.Remove(vtx.edges.Find(t => t.Item1 == vertex));
			}
            
			vertices.Remove(vertex);
		}
		public void RemoveVertex(int index)
		{
			RemoveVertex(vertices[index]);
		}

        public bool HasVertex(WeightedDirectedVertex<T> vertex) => vertices.Contains(vertex);

        List<WeightedDirectedVertex<T>> visited;
        WeightedDirectedVertex<T> item;
        public WeightedDirectedVertex<T> DepthFirstTraversal(WeightedDirectedVertex<T> root, T searchVal)
		{
			item = null;
            visited = new List<WeightedDirectedVertex<T>>();
			DepthFirstTraversalHelper(root, searchVal);
			return item;
		}

        void DepthFirstTraversalHelper(WeightedDirectedVertex<T> thisNode, T searchVal)
		{
			if (item != null) return;

            thisNode.edges.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            foreach (var t in thisNode.edges)
			{
                var n = t.Item1;
				if (visited.Contains(n)) continue;
				if (n.val.CompareTo(searchVal) == 0)
				{
					item = n;
					return;
				}

				visited.Add(n);
				DepthFirstTraversalHelper(n, searchVal);

			}

		}

		

		public WeightedDirectedVertex<T> BreadthFirstTraversal(WeightedDirectedVertex<T> root, T searchVal)
		{
            visited = new List<WeightedDirectedVertex<T>>();
			Queue<WeightedDirectedVertex<T>> q = new Queue<WeightedDirectedVertex<T>>();

			q.Enqueue(root);
			while (q.Count != 0)
			{

				var n = q.Peek();
				if (n.val.CompareTo(searchVal) == 0)
				{
					return n;
				}
				q.Dequeue();

                n.edges.Sort((x, y) => x.Item2.CompareTo(y.Item2));
                foreach (var i in n.edges)
				{
                    if (!visited.Contains(i.Item1)) q.Enqueue(i.Item1);
				}
				visited.Add(n);

			}

			Console.WriteLine("hi!");
			return null;
		}

		public List<WeightedDirectedVertex<T>> DijkstraFind(WeightedDirectedVertex<T> root, T searchVal)
		{
            var vertexInfo = new Dictionary<WeightedDirectedVertex<T>, Tuple<WeightedDirectedVertex<T>, float>>();
			var searched = new List<WeightedDirectedVertex<T>>();
			var q = new Queue<WeightedDirectedVertex<T>>();
            WeightedDirectedVertex<T> nodeToFind;

			q.Enqueue(root);

            vertexInfo.Add(root, new Tuple<WeightedDirectedVertex<T>, float>(null, 0));

			while (q.Count != 0)
			{

				var n = q.Peek();
				
				q.Dequeue();

				n.edges.Sort((x, y) => x.Item2.CompareTo(y.Item2));
				foreach (var i in n.edges)
				{
                    if (!searched.Contains(i.Item1))
                    {
                        q.Enqueue(i.Item1);
                        if (vertexInfo.ContainsKey(i.Item1))
                        {
                            if(vertexInfo[i.Item1].Item2 > vertexInfo[n].Item2 + i.Item2)
							vertexInfo[i.Item1] = new Tuple<WeightedDirectedVertex<T>, float>(n, vertexInfo[n].Item2 + i.Item2);
                        }
                        else
                        {
                            vertexInfo.Add(i.Item1, new Tuple<WeightedDirectedVertex<T>, float>(n, vertexInfo[n].Item2 + i.Item2));
                            if (i.Item1.val = searchVal)
                                nodeToFind = i.Item1;
                        }
                    }
				}
				searched.Add(n);

                if (q.Count == 0)
				{
                    var path = new List<WeightedDirectedVertex<T>>();
                    while(true){
                        var dictEntry = vertexInfo[path[path.Count - 1]];
                        if(dictEntry.Item2 == 0){
                            return path;
                        }else{
                            path.Add(dictEntry.Item1);
                        }
                    }
				}



            }

			Console.WriteLine("hi!");
			return null;
		}

	}
}
