using UnitTesting_Structures_Patterns.Structures.BasicStructures;

namespace UnitTesting_Structures_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<int> dlist = new CircularLinkedList<int>();

            dlist.Add(1);
            dlist.Add(2);
            dlist.Add(3);
            dlist.Add(4);
            dlist.Add(5);

            dlist.AddToTheStart(-1);

            dlist.Delete(3);

            dlist.Delete();

        }
    }
}
