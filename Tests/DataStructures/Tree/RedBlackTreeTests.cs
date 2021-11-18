using System;
using DataStructures.Tree;
using Xunit;

namespace Tests.DataStructures.Tree
{
    public class RedBlackTreeTests
    {
        // [Fact]
        [Fact(Skip = "DUMMY TEST. NEEDS TO BE REWRITTEN.")]
        public void RedBlackTreeTest()
        {
            var bst = new RedBlackTree<int>();

            bst.Insert(1);
            bst.Insert(2);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);
            bst.Insert(7);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(10);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(13);
            bst.Insert(14);
            bst.Insert(15);
            
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

            bst.Delete(15);

            bst.PrintTree();

            Assert.True(false);
        }
    }
}