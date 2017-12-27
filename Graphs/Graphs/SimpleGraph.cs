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
    }
}
