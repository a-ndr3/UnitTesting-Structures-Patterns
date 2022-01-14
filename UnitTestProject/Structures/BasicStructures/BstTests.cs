using System;
using System.Text;
using System.Linq;
using Xunit;
using UnitTesting_Structures_Patterns.Structures.BasicStructures;
using UnitTesting_Structures_Patterns.Structures.TreeBased;

namespace UnitTestProject.Structures.BasicStructures
{
    public class BstTests
    {
        BST<BstValue> collection;
        public BstTests()
        {
            collection = new BST<BstValue>();
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void GetEnumerator_ForAnyData_ReturnsData(BstValue aa)
        {
            var input = new System.Collections.Generic.List<BstValue>
            {
                new BstValue(1),
                new BstValue(2),
                new BstValue(3),
                new BstValue(5),
                new BstValue(7)
            };
            foreach(var a in input) 
                collection.Add(a);

            var result = collection.TraverseInOrderArrayEnum().ToList();
        }
        public static System.Collections.Generic.IEnumerable<object[]> GetData()
        {
            yield return new object[] {new BstValue(1)};
        }
    }

    public struct BstValue : IComparable
    {
        public BstValue(int a) {value = a;}

        public int value;

        public int CompareTo(object obj)
        {
            if (obj is BstValue other)
            {
                return value == other.value
                    ? 0
                    : value > other.value 
                        ? 1 
                        : -1;
            }

            return -1;
        }
    }
}
