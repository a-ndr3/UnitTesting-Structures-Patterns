using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestProject
{
    public class UnitTestsExample
    {
        MyService myService;
        public UnitTestsExample()
        {
            myService = new MyService();
        }

        // single scenario
        // single values
        [Fact]
        // MethodToTest_InputData_ExpectedResult
        public void DoSomething_ForPositiveNumbers_ReturnsPositiveResult()
        {
            // Arrange
            var a = 5;
            var b = 6;
            var expectedResult = 11;

            // Act
            var actual = myService.DoSomething(a, b);

            // Assert
            Assert.Equal(expectedResult, actual);
        }

        // single scenario
        // multiple input/expected values
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test2(int value1, int value2, int expectedResult)
        {
            //var actual = myService.DoSomething(a, b);
            Assert.Equal(expectedResult, value1 + value2);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] {5, 6, 11};
            yield return new object[] {1, 1, 2};
            yield return new object[] {0, 0, 0};
        }
    }

    class MyService
    {
        public int DoSomething(int a, int b) { return a + b;}
    }
}
