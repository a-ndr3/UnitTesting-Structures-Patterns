using System.Linq;
using UnitTesting_Structures_Patterns.Structures;
using Xunit;

namespace UnitTestProject.Structures.BasicStructures
{
    public class HashTableTests
    {
        HashTable<int> ht;
        public HashTableTests()
        {
            ht = new HashTable<int>();
        }

        [Theory]
        [InlineData("qwerty", 8903)]
        [InlineData("asdfg", 2120)]
        [InlineData("!@#$%&^**", 3401)]
        [InlineData("1234567", 6977)]
        public void GetHashTest_ForDifferentKeys_ReturnsIntHash(string data, int expectedResult)
        {
            var mtInfo = typeof(HashTable<int>).GetMethod("GetHash", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            // Act
            var res = mtInfo.Invoke(ht, new object[] { data });

            // Assert
            Assert.Equal(res, expectedResult);
        }


        [Theory]
        [InlineData(15023)]
        [InlineData(123456)]
        [InlineData(546789)]
        public void AddCapacityTest_GetsOutOfArrayIndexes_ReturnsResultedCapacity(int index)
        {
            var mtInfo = typeof(HashTable<int>).GetMethod("AddCapacity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var capacityInfo = typeof(HashTable<int>).GetField("capacity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static);
            //Act
            mtInfo.Invoke(ht, new object[] { index });
            var res = capacityInfo.GetValue(ht);
            //Assert
            Assert.True(System.Convert.ToInt32(res) >= index);
        }


        [Theory]
        [InlineData(new object[] { "VVVv222", 1234 })]
        [InlineData(new object[] { "::&*((^^^%", 5556 })]
        [InlineData(new object[] { "~~2321SssWW", 1893 })]
        public void GetValueTest_GetsKeys_ReturnsIEnumerableValues(params object[] obj)
        {
            ht.Add(obj[0].ToString(), (int)obj[1]);
            ht.Add(obj[0].ToString(), 555555);
            //Act
            var res = ht.GetValue(obj[0].ToString());
            //Assert
            Assert.Equal((int)obj[1], res.ElementAt(0));
        }
    }
}
