using System;

namespace UnitTesting_Structures_Patterns.Patterns.Creational
{
    public interface IMobile
    {
        void GetMobile();
    }

    public interface IBattery
    {
        void GetBattery();
    }


    public class SamsungBattery : IBattery
    {
        public void GetBattery()
        {
            Console.WriteLine("Samsung battery is 100%");
        }
    }

    public class SonyBattery : IBattery
    {
        public void GetBattery()
        {
            Console.WriteLine("Sony battery is 50%");
        }
    }



    public enum ModelType
    {
        Samsung1 = 1,
        Samsung2 = 2,
        Sony1 = 3,
        Sony2 = 4,
        iPhone5 = 5,
        iPhone6 = 6
    }

    public class Samsung1 : IMobile
    {
        public void GetMobile()
        {
            Console.WriteLine("Samsung1 is here");
        }
    }

    public class Samsung2 : IMobile
    {
        public void GetMobile()
        {
            Console.WriteLine("Samsung2 is here");
        }
    }

    public class Sony1 : IMobile
    {
        public void GetMobile()
        {
            Console.WriteLine("Sony1 is here");
        }
    }


    public class Sony2 : IMobile
    {
        public void GetMobile()
        {
            Console.WriteLine("sony2 is here");
        }
    }



    public abstract class IMobileFactory
    {
        public abstract IMobile GetMobile(ModelType type);
        public abstract IBattery GetBattery(ModelType type);
    }


    public class SamsungFactory : IMobileFactory
    {
        public override IBattery GetBattery(ModelType type)
        {
            switch (type)
            {
                case ModelType.Samsung1:
                    return new SamsungBattery();
                case ModelType.Samsung2:
                    return new SamsungBattery();
                default: return null;
            }
        }

        public override IMobile GetMobile(ModelType type)
        {
            switch (type)
            {
                case ModelType.Samsung1:
                    return new Samsung1();
                case ModelType.Samsung2:
                    return new Samsung2();
                default: return null;
            }
        }
    }

    public class SonyFactory : IMobileFactory
    {
        public override IBattery GetBattery(ModelType type)
        {
            switch (type)
            {
                case ModelType.Sony1:
                    return new SonyBattery();
                case ModelType.Sony2:
                    return new SonyBattery();
                default: return null;
            }
        }

        public override IMobile GetMobile(ModelType type)
        {
            switch (type)
            {
                case ModelType.Sony1:
                    return new Sony1();
                case ModelType.Sony2:
                    return new Sony2();
                default: return null;
            }
        }
    }


}
