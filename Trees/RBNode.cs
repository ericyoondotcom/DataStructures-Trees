using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    abstract class RBNode<T>
    {
        public Enums.Colors color { get; set; }
        public RBNode<T> parent { get; set; }
        public RBNode<T> left { get; set; }
        public RBNode<T> right { get; set; }
        public T val { get; }

    }
}
