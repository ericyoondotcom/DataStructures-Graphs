using System;
using System.Collections.Generic;

namespace Graphs
{
    public class SimpleGraph<T>
    {
        public List<SimpleVertex<T>> vertices;

        public SimpleGraph()
        {
            vertices = new List<SimpleVertex<T>>();
        }
        public SimpleGraph(List<SimpleVertex<T>> vertices)
        {
            this.vertices = vertices;
        }

        public void AddEdge(SimpleVertex<T> a, SimpleVertex<T> b){
            SimpleVertex<T> aVertex = vertices.Find(i => i == a);
            SimpleVertex<T> bVertex = vertices.Find(i => i == b);
            aVertex.neighbors.Add(bVertex);
            bVertex.neighbors.Add(aVertex);

        }

        public SimpleVertex<T> AddVertex(T newValue) => AddVertex(new SimpleVertex<T>(newValue));

        public SimpleVertex<T> AddVertex(SimpleVertex<T> newVertex){
            vertices.Add(newVertex);
            foreach (SimpleVertex<T> i in vertices){
                if(i == newVertex){
                    return i;
                }
            }
            throw new Exception("Can't find the newly added Vertex!");
        }

        public void RemoveVertex(SimpleVertex<T> vertex){
            foreach (SimpleVertex<T> possibleNeighbor in vertices){ //any better way to do this? Is there a List.Map? Can I use List.ConvertAll?
                if(possibleNeighbor.neighbors.Contains(vertex)){
                    possibleNeighbor.neighbors.Remove(vertex);
                }
            }
            vertices.Remove(vertex);
        }
        public void RemoveVertex(int index){
            RemoveVertex(vertices[index]);
        }

        public bool HasVertex(SimpleVertex<T> vertex) => vertices.Contains(vertex);

        public void DepthFirstTraversal(SimpleVertex<T> root){
            
        }

        public void BreadthFirstTraversal(SimpleVertex<T> root){
            
        }
    }
}
