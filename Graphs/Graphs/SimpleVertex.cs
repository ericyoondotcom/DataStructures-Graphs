using System;
using System.Collections.Generic;

namespace Graphs
{
    public class SimpleVertex<T>
    {
        public List<SimpleVertex<T>> neighbors;
        public T val;
        public SimpleVertex(T val, List<SimpleVertex<T>> neighbors = null)
        {
            if(neighbors == null){
                this.neighbors = new List<SimpleVertex<T>>();
            }else{
                this.neighbors = neighbors;
            }
            this.val = val;
        }
    }
}
