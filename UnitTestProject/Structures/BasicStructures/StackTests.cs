using System;
using System.Text;
using System.Linq;
using Xunit;
using UnitTesting_Structures_Patterns.Structures.BasicStructures;

namespace UnitTestProject.Structures.BasicStructures
{
    public class StackTests
    {
        Stack<int> stack;
        public StackTests()
        {
            stack = new Stack<int>(5);
        }

        [Fact]
        public void GetEnumerator_ForAnyData_ReturnsData()
        {
            // Arrange
            var data = new int[] {1,2,3};
            foreach(var a in data)
            {
                stack.Push(a);
            }

            // Act
            var result = stack.ToArray();

            // Assert
            Assert.Equal(data, result);
        }
    }
}
