using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital.Structures
{
    public class SingleNode<T>
    {
        public SingleNode<T> Next { get; set; }
        public T Value { get; set; }

        public SingleNode(T value)
        {
            Value = value;
        }

        public override string ToString() => $"{Value}";
    }
}
