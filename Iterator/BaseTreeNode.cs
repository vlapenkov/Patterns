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

        private Lazy<List<BaseTreeNode<T>>> _children = new Lazy<List<BaseTreeNode<T>>>(
            delegate ()
            {
                Console.WriteLine("_children added");
                return new List<BaseTreeNode<T>>();
            }
            //() => new List<BaseTreeNode<T>>()
            );

        /// <summary> Данные узла </summary>
        public virtual T Data { get; protected set; }

        /// <summary> Дочерние элементы </summary>
        public virtual IEnumerable<BaseTreeNode<T>> Children => _children.Value;

        /// <summary> Родительский элемент </summary>        
        public BaseTreeNode<T>? Parent { get; protected set; }

        #endregion


        /// <summary> Добавить дочерний элемент </summary>
        public void AddChild(BaseTreeNode<T> child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));

            child.Parent = this;

            _children.Value.Add(child);
        }

        public override string ToString()
        {
            return Data + " root";
        }
    }
}
