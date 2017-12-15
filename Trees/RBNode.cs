using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    abstract class RBNode<T>
    {
        public virtual Enums.Colors color { get; set; }
        public virtual RBNode<T> parent { get; set; }
        public virtual RBNode<T> left { get; set; }
        public virtual RBNode<T> right { get; set; }
        public virtual T val { get; set; }

    }
}
