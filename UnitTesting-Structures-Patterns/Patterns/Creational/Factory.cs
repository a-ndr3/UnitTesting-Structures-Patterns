namespace UnitTesting_Structures_Patterns.Patterns.Creational
{
    public interface IAnimal
    {
        void MakeNoise();

        int age { get; set; }
        bool furr { get; set; }

    }

    /// <summary>
    /// aka Фабричный метод.
    /// порождающий паттерн, который определяет общий интерфейс для создания обьектов в суперклассе, позволяя подклассам изменять тип создаваемых обьектов.
    /// </summary>
    public abstract class FactoryMethod
    {
        public abstract IAnimal GetAnimal();

    }







    public class DogFactory : FactoryMethod
    {
        public override IAnimal GetAnimal()
        {
            return new Dog();
        }
    }

    public class CatFactory : FactoryMethod
    {
        public override IAnimal GetAnimal()
        {
            return new Cat();
        }
    }

    public class DuckFactory : FactoryMethod
    {
        public override IAnimal GetAnimal()
        {
            return new Duck();
        }
    }








    public class Dog : IAnimal
    {
        public int age { get; set; }
        public bool furr { get; set; }

        public void MakeNoise()
        {
            System.Console.WriteLine("Bark");
        }
    }


    public class Cat : IAnimal
    {
        public int age { get; set; }
        public bool furr { get; set; }

        public void MakeNoise()
        {
            System.Console.WriteLine("Meow");
        }
    }

    public class Duck : IAnimal
    {
        public int age { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool furr { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void MakeNoise()
        {
            System.Console.WriteLine("Quack");
        }
    }

}
