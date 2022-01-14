using System.Linq;
using UnitTesting_Structures_Patterns.Interfaces;
using UnitTesting_Structures_Patterns.Structures.BasicStructures;
using UnitTesting_Structures_Patterns.Structures.TreeBased;
using Xunit;


namespace UnitTestProject
{
    public class CustomCollectionTest
    {
        public class CustomCollectionsOutputTest
        {
            Stack<string> stack;
            Queue<string> queue;
            BST<string> bst;
            public CustomCollectionsOutputTest()
            {
                stack = new Stack<string>(5);
                queue = new Queue<string>(5);
                bst = new BST<string>();
            }

            [Fact]
            public void TestCollectionsOutput()
            {
                string[] values = new string[] { "1", "2", "3","5","7" };

                foreach (var v in values)
                {
                    stack.Add(v.ToString());
                    queue.Enqueue(v.ToString());
                    bst.Add(v);
                }

                var resultStack = stack.ToArray();
                var resultQueue = queue.ToArray();
                var resultBst = bst.TraverseInOrderArray().ToArray();
                var resultBstEnum = bst.TraverseInOrderArrayEnum().ToArray();


                Assert.Equal(values.ToArray(), resultStack);
                Assert.Equal(values.ToArray(), resultQueue);
                Assert.Equal(values.ToArray(), resultBst);
                Assert.Equal(values.ToArray(), resultBstEnum);
            }

            
        }
        
        public void TestCollection(ICustomCollection<int> col)
        {
            col.Add(5);
            var t = col.Delete();
            Assert.Equal(5, t);
        }

        [Fact]
        public void TestStack()
        {
            TestCollection(new Stack<int>(1));
        }

        [Fact]
        public void TestQueue()
        {
            TestCollection(new Queue<int>(1));
        }
    }
}
