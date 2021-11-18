using System;
using DataStructures.Tree;
using NUnit.Framework;

namespace Tests.DataStructures.Tree
{
    public class BinarySearchTreeTests
    {
        [Test]
        [Ignore("DUMMY TEST. NEEDS TO BE REWRITTEN")]
        public void BinarySearchTreeTest()
        {
            var bst = new BinarySearchTree<int>();

            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(14);
            
            bst.Inorder(key =>
            {
                Console.Write($"{key} ");
            });
            Console.WriteLine();
            bst.Preorder(key =>
            {
                Console.Write($"{key} ");
            });
            Console.WriteLine();
            bst.Postorder(key =>
            {
                Console.Write($"{key} ");
            });
            
            bst.PrintTree();

            bst.Delete(3);

            bst.PrintTree();

            Assert.Fail();
        }
    }
}