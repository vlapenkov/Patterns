using System;
using System.Collections.Generic;

namespace Iterator
{
    public class BaseTreeNode<T> where T : class
    {

        public BaseTreeNode(T data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        #region PrivateMembers

        private IList<BaseTreeNode<T>> _children = new List<BaseTreeNode<T>>();

        /// <summary> Данные узла </summary>
        public virtual T Data { get; private set; }

        /// <summary> Дочерние элементы </summary>
        public virtual IEnumerable<BaseTreeNode<T>> Children => _children;

        /// <summary> Родительский элемент </summary>        
        public BaseTreeNode<T> Parent { get; private set; }

        #endregion


        /// <summary> Добавить дочерний элемент </summary>
        public void AddChild(BaseTreeNode<T> child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));

            child.Parent = this;

            _children.Add(child);
        }
    }
}
