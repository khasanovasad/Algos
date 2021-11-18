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

            for (int i = 1; i <= 15; ++i)
            {
                bst.Insert(i);
            }
            
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