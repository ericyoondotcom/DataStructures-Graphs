using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Heap<T>
    {
        public T[] Data { get; private set; }
        IComparer<T> sortfn;
        public int Count { get; private set; }
        public Heap(IComparer<T> sort, int capacity = 100)
        {
            Data = new T[capacity];
            sortfn = sort;
            Count = 0;
        }
        public T Pop(){
            T removed = Data[0];
            int pos = 0;
            Data[0] = Data[--Count];

            while(true){
                
                int child;
                int left;
                int right;
                left = GetLeft(pos);
                right = GetRight(pos);

                if (right >= Count && left >= Count) break;

                if(right >= Count || sortfn.Compare(Data[left], Data[right]) < 0){
                    child = left;
                }else{
                    child = right;
                }


                if (sortfn.Compare(Data[child],Data[pos]) > 0)
				{
					break;
				}

                T swap = Data[child];
                Data[child] = Data[pos];
                Data[pos] = swap;
                pos = child;
            }

            return removed;
        }
        public void Push(T newVal){
            int pos = Data.Length;
            Data[pos] = newVal;
            while(true){
                int parent = GetParent(pos);

                if (true /*compare FN*/ || pos == 0){
                    break;
                }

                T swap = Data[parent];
                Data[parent] = Data[pos];
                Data[pos] = swap;
                pos = parent;
            }
        }

        public int GetParent(int index) => (index - 1) / 2;
		public int GetLeft(int index) => (index * 2) + 1;
        public int GetRight(int index) => (index * 2) + 2;

	}
}
