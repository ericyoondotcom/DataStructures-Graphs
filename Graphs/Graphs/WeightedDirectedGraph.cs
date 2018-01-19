using System;
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
			foreach (WeightedDirectedVertex<T> possibleNeighbor in vertices)
			{ //any better way to do this? Is there a List.Map? Can I use List.ConvertAll?
                if (possibleNeighbor.edges.Find)
				{
					possibleNeighbor.neighbors.Remove(vertex);
				}
			}
			vertices.Remove(vertex);
		}
		public void RemoveVertex(int index)
		{
			RemoveVertex(vertices[index]);
		}

		public bool HasVertex(SimpleVertex<T> vertex) => vertices.Contains(vertex);

		List<SimpleVertex<T>> visited;
		SimpleVertex<T> item;
		public SimpleVertex<T> DepthFirstTraversal(SimpleVertex<T> root, T searchVal)
		{
			item = null;
			visited = new List<SimpleVertex<T>>();
			DepthFirstTraversalHelper(root, searchVal);
			return item;
		}

		void DepthFirstTraversalHelper(SimpleVertex<T> thisNode, T searchVal)
		{
			if (item != null) return;
			foreach (SimpleVertex<T> n in thisNode.neighbors)
			{
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

		Queue<SimpleVertex<T>> q;

		public SimpleVertex<T> BreadthFirstTraversal(SimpleVertex<T> root, T searchVal)
		{
			visited = new List<SimpleVertex<T>>();
			q = new Queue<SimpleVertex<T>>();

			q.Enqueue(root);
			while (q.Count != 0)
			{

				var n = q.Peek();
				if (n.val.CompareTo(searchVal) == 0)
				{
					return n;
				}
				q.Dequeue();
				foreach (var i in n.neighbors)
				{
					if (!visited.Contains(i)) q.Enqueue(i);
				}
				visited.Add(n);

			}

			Console.WriteLine("hi!");
			return null;
		}
	}
}
