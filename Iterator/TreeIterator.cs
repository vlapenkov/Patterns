using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class TreeIterator<T> where T : class
    {
        BaseTreeNode<T> _current;
        public TreeIterator(BaseTreeNode<T> root)
        {
            _current = root;
        }

        public IEnumerable<BaseTreeNode<T>> GetElements()
        {
            IEnumerable<BaseTreeNode<T>> GetElements(BaseTreeNode<T> currentNode)
            {
                yield return currentNode;

                foreach (var child in currentNode.Children)
                {
                    foreach (var element in GetElements(child))
                        yield return element;
                }
            }

            yield return _current;

            foreach (var child in _current.Children)
            {
                foreach (var element in GetElements(child))
                    yield return element;
            }
        }




    }
}
