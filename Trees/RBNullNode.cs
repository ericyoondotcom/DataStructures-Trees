using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class RBNullNode<T> : RBNode<T>
    {
        public RBNullNode()
        {
			//To workaround https://developercommunity.visualstudio.com/content/problem/171231/virtual-property-always-showing-base-value-in-debu.html
			base.color = Enums.Colors.black;
        }

        private T v;
        private RBNode<T> rbnv;        
        public override RBNode<T> parent { get; set; }
        public override RBNode<T> left { get { return rbnv; } set { throw new NotImplementedException("Sorry..."); } }
        public override RBNode<T> right { get { return rbnv; } set { throw new NotImplementedException("Sorry..."); } }
        public override Enums.Colors color { get { return Enums.Colors.black; } set { throw new NotImplementedException("Oopsies!");} }
        public override T val => v;
    }
}
