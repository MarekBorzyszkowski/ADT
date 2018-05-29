using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// Wizualizacja drzewa AVL:
// https://www.cs.usfca.edu/~galles/visualization/AVLtree.html
// opis działania:
// http://eduinf.waw.pl/inf/alg/001_search/0119.php
//
namespace ADTAVLTree {
    public class ADTAVLTree<T> where T : IComparable {
        class Node {
            public T Data;
            public Node Left;
            public Node Right;
            public Node(T data) {
                this.Data = data;
            }
            public bool NodeContains(T t) {
                if (t.CompareTo(Data) == 0)
                    return true;
                else if (t.CompareTo(Data) < 0)
                {
                    if (Left == null)
                        return false;
                    else
                        return Left.NodeContains(t);
                }
                else
                {
                    if (Right == null)
                        return false;
                    else
                        return Right.NodeContains(t);
                }
            }
        }
        Node root;
        public ADTAVLTree() {
            root = null;
        }
        public ADTAVLTree<T> Add(T data) {
            Node newItem = new Node(data);
            if (root == null)
                root = newItem;
            else
                root = RecursiveInsert(root, newItem);
            return this;
        }
        private Node RecursiveInsert(Node current, Node n) {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Data.CompareTo(current.Data) < 0)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = balance_tree(current);
            }
            else 
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private Node balance_tree(Node current) {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
                if (balance_factor(current.Left) > 0)
                    current = RotateLL(current);
                else
                    current = RotateLR(current);
            else if (b_factor < -1)
                if (balance_factor(current.Right) > 0)
                    current = RotateRL(current);
                else
                    current = RotateRR(current);
            return current;
        }
        public ADTAVLTree<T> Delete(T target) {//and here
            root = Delete(root, target);
            return this;
        }
        private Node Delete(Node current, T target) {
            Node parent;
            if (current == null) return null;
            else
            {
                //left subtree
                if (target.CompareTo(current.Data) < 0)
                {
                    current.Left = Delete(current.Left, target);
                    if (balance_factor(current) == -2)
                        if (balance_factor(current.Right) <= 0)
                            current = RotateRR(current);
                        else
                            current = RotateRL(current);
                }
                //right subtree
                else if (target.CompareTo(current.Data) > 0)
                {
                    current.Right = Delete(current.Right, target);
                    if (balance_factor(current) == 2)
                        if (balance_factor(current.Left) >= 0)
                            current = RotateLL(current);
                        else
                            current = RotateLR(current);
                }
                //if target is found
                else
                {
                    if (current.Right != null)
                    {
                        //delete its successor
                        parent = current.Right;
                        while (parent.Left != null)
                            parent = parent.Left;
                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);
                        if (balance_factor(current) == 2)
                            if (balance_factor(current.Left) >= 0)
                                current = RotateLL(current);
                            else
                                current = RotateLR(current);
                    }
                    else
                    {   //if current.left != null
                        return current.Left;
                    }
                }
            }
            return current;
        }
        private Node Find(T target, Node current) {
            if (target.CompareTo(current.Data) == 0)
                return current;

            if (target.CompareTo(current.Data) < 0)
                return Find(target, current.Left);
            else
                return Find(target, current.Right);
        }
        public bool Contains(T t) {
            if (root == null)
                return false;
            else
                return root.NodeContains(t);
        }

        public void DisplayTree() {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        public void PrettyPrintTree() {
            _PrettyPrintTree(root, "-");
        }

        private void _PrettyPrintTree(Node root, String space) {
            if (root.Left == null && root.Left == null)
                Console.WriteLine("{0}{1}", space, root.Data);
            else
            {
                if (root.Left != null)
                    _PrettyPrintTree(root.Left, space + space);
                Console.WriteLine("{0}{1}", space, root.Data);
                if (root.Right != null)
                    _PrettyPrintTree(root.Right, space + space);
            }
        }
        private void InOrderDisplayTree(Node current) {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                Console.Write("({0}) ", current.Data);
                InOrderDisplayTree(current.Right);
            }
        }
        private void PreOrderDisplayTree(Node current) {
            if (current != null)
            {
                Console.Write("({0}) ", current.Data);
                PreOrderDisplayTree(current.Left);
                PreOrderDisplayTree(current.Right);
            }
        }
        private void PostOrderDisplayTree(Node current) {
            if (current != null)
            {
                PostOrderDisplayTree(current.Left);
                PostOrderDisplayTree(current.Right);
                Console.Write("({0}) ", current.Data);
            }
        }
        private int max(int l, int r) {
            return l > r ? l : r;
        }
        private int getHeight(Node current) {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.Left);
                int r = getHeight(current.Right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        public int Height() {
            return getHeight(root);
        }
        private int balance_factor(Node current) {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node RotateRR(Node parent) {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent) {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent) {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent) {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}