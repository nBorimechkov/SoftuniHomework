using HashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace P04.OrderedSet
{
    class OrderedSet<T> : IEnumerable<T> where T : IComparable
    {
        private HashDict<T, Node<T>> set;
        private Node<T> root;
        private int count;

        public OrderedSet()
        {
            this.set = new HashDict<T, Node<T>>();
            this.root = null;
            this.Count = 0;
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public void Add(T element)
        {
            if (root == null)
            {
                this.root = new Node<T>(element);
                this.Count++;
            }
            else
            {
                this.Add(element, root);
            }
        }
        private void Add(T element, Node<T> parent)
        {
            int compare = parent.Value.CompareTo(element);
            if (compare > 0)
            {
                if (parent.Left == null)
                {
                    parent.Left = new Node<T>(element);
                    parent.Left.Parent = parent;
                    this.set.Add(element, parent.Left);
                    this.Count++;
                }
                else
                {
                    this.Add(element, parent.Left);
                }
            }
            else if (compare < 0)
            {
                if (parent.Right == null)
                {
                    parent.Right = new Node<T>(element);
                    parent.Right.Parent = parent;
                    this.set.Add(element, parent.Right);
                    this.Count++;
                }
                else
                {
                    this.Add(element, parent.Right);
                }
            }
        }

        private bool Contains(T element)
        {
            return this.set.ContainsKey(element);
        }

        public void Remove(T element)
        {
            if (!this.set.ContainsKey(element))
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node<T> toRemove = this.set[element];
                Node<T> leftChild = toRemove.Left;
                Node<T> rightChild = toRemove.Right;
                Node<T> parent = toRemove.Parent;

                int compare = parent.Value.CompareTo(toRemove.Value);

                toRemove = rightChild != null ? rightChild : leftChild;

                if (toRemove != null)
                {
                    toRemove.Left = leftChild;
                }

                if (compare < 0)
                {
                    parent.Right = toRemove;
                }
                else
                {
                    parent.Left = toRemove;
                }
                
                this.set.Remove(element);
                this.Count--;
            }
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> list = new List<T>();
            this.EachInOrder(node => list.Add(node));
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
