using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class RBNullNode<T> : RBNode<T>
    {
        private T v;
        private RBNode<T> rbnv;
        public RBNode<T> parent { get; set; }
        public RBNode<T> left { get { return rbnv; } set { throw new NotImplementedException("Sorry..."); } }
        public RBNode<T> right { get { return rbnv; } set { throw new NotImplementedException("Sorry..."); } }
        public Enums.Colors color { get; set; }
        public T val => v;
    }
}
