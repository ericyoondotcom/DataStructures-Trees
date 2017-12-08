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
        public override RBNode<T> parent { get; set; }
        public override RBNode<T> left { get { return rbnv; } set { throw new NotImplementedException("Sorry..."); } }
        public override RBNode<T> right { get { return rbnv; } set { throw new NotImplementedException("Sorry..."); } }
        public override Enums.Colors color { get; set; }
        public override l => v;
    }
}
