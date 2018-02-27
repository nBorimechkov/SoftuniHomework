namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node root;
        private Dictionary<T, Node> hierarchy;

        private class Node
        {
            public Node(T value, Node parent = null)
            {
                this.Value = value;
                this.Parent = parent;
                this.Children = new List<Node>();
            }

            public T Value { get; private set; }

            public Node Parent { get; set; }

            public List<Node> Children { get; set; }
        }

        public Hierarchy(T root)
        {
            this.root = new Node(root);
            this.hierarchy = new Dictionary<T, Node>();
            this.hierarchy.Add(root, new Node(root));
        }

        public int Count
        {
            get
            {
                return this.hierarchy.Count;
            }
        }

        public void Add(T element, T child)
        {
            if (this.hierarchy.ContainsKey(element))
            {
                Node node = Find(element);
                if (!Contains(child))
                {
                    node.Children.Add(new Node(child, node));
                    hierarchy.Add(child, new Node(child, node));
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Remove(T element)
        {
            Node node = Find(element);
            if (node == null)
            {
                throw new ArgumentException();
            }
            if (this.root.Value.Equals(node.Value))
            {
                throw new InvalidOperationException();
            }

            Node parent = Find(GetParent(element));

            if (node.Children.Count > 0)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = parent;
                    parent.Children.Add(child);
                    hierarchy[child.Value] = child;
                }
            }
            
            int childIndex = parent.Children.IndexOf(parent.Children.First(x => x.Value.Equals(node.Value)));
            parent.Children.RemoveAt(childIndex);
            node.Parent = null;
            hierarchy.Remove(node.Value);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            Node node = Find(item);
            List<T> children = new List<T>();
            foreach (var child in node.Children)
            {
                children.Add(child.Value);
            }
            
            return children;
        }

        public T GetParent(T item)
        {
            Node node = Find(item);
            if (node == null)
            {
                throw new ArgumentException();
            }
            if (this.root.Value.Equals(node.Value))
            {
                return default(T);
            }

            return node.Parent.Value;
        }

        public bool Contains(T value)
        {
            Node node = Find(value);
            if (node != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> commonElements = new List<T>();

            foreach (var key in this.hierarchy.Keys)
            {
                if (other.Contains(key))
                {
                    commonElements.Add(key);
                }
            }

            return commonElements;
        } 

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();
            Node current = this.root;
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                yield return current.Value;

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
            
            //foreach (var key in this.hierarchy.Keys)
            //{
            //    yield return key;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private Node Find(T element)
        {
            if (hierarchy.ContainsKey(element))
            {
                return hierarchy[element];
            }
            else
            {
                return null;
            }
        }
    }
}