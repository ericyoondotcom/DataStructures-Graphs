using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public class Heap<T>
    {



        public T[] Data { get; private set; }
        public Comparison<T> sortfn { get; private set; }
        public int Count { get; private set; }

        public object Current => throw new NotImplementedException();

        public Heap(Comparison<T> sort, int capacity = 100)
        {
            Data = new T[capacity];
            sortfn = sort;
            Count = 0;
        }

        public static T[] HeapSort(T[] data, Heap<T> heap){
            T[] newData = new T[data.Length];
            foreach(T t in data){
                heap.Push(t);
            }
            int pos = 0;
            while(heap.Count > 0){
                newData[pos] = heap.Pop();
                pos++;
            }
            return newData;
        }

        public override string ToString()
        {
            string text = "";
            foreach(T t in Data){
                text += t + ", ";
            }
            return text;

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

                if(right >= Count ||  sortfn(Data[left], Data[right]) < 0){
                    child = left;
                }else{
                    child = right;
                }


                if (sortfn(Data[child],Data[pos]) > 0)
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
            if(Count == 0){
                Data[Count] = newVal;
                Count++;
                return;
            }
            int pos = Count;
            Data[pos] = newVal;
            while(true){
                int parent = GetParent(pos);

                if (sortfn(Data[parent], Data[pos]) < 0 || pos == 0){
                    break;
                }

                T swap = Data[parent];
                Data[parent] = Data[pos];
                Data[pos] = swap;
                pos = parent;

            }
            Count++;
        }

        public T Peek() => Data[0];

        public int GetParent(int index) => (index - 1) / 2;
		public int GetLeft(int index) => (index * 2) + 1;
        public int GetRight(int index) => (index * 2) + 2;

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
