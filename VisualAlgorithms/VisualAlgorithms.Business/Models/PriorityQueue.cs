using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int childIndex = data.Count - 1;
            while(childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (data[childIndex].CompareTo(data[parentIndex]) >= 0)
                    break;
                T temp = data[childIndex];
                data[childIndex] = data[parentIndex];
                data[parentIndex] = temp;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            int lastIndex = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[1];
            data.RemoveAt(lastIndex);

            --lastIndex;
            int parentIndex = 0;
            while (true)
            {
                int childIndex = parentIndex * 2 + 1;
                if (childIndex > parentIndex)
                    break;
                int rc = childIndex + 1;
                if (rc <= lastIndex && data[rc].CompareTo(data[childIndex]) < 0)
                    childIndex = rc;
                if (data[parentIndex].CompareTo(data[childIndex]) <= 0)
                    break;
                T temp = data[parentIndex];
                data[parentIndex] = data[childIndex];
                data[childIndex] = temp;
                parentIndex = childIndex;
            }
            return frontItem;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i) {
                s += data[i].ToString() + " ";
            }
            s += "count = " + data.Count;
            return s;
        }

        public int Count() {
            return data.Count;
        }

        public T Peek() {
            T frontItem = data[0];
            return frontItem;
        }

        public bool IsConsistent() {
            if (data.Count == 0)
                return true;
            int lastIndex = data.Count - 1;
            for (int parentIndex = 0; parentIndex < data.Count; ++parentIndex) {
                int leftChildIndex = 2 * parentIndex + 1;
                int rightChildIndex = 2 * parentIndex + 2;
                if (leftChildIndex <= lastIndex && data[parentIndex].CompareTo(data[leftChildIndex]) > 0)
                    return false;
                if (rightChildIndex <= lastIndex && data[parentIndex].CompareTo(data[rightChildIndex]) > 0)
                    return false;
            }
            return true;
        }
    }
}
