using UnitTesting_Structures_Patterns.Patterns.Structural;

namespace UnitTesting_Structures_Patterns
{
    class Program
    {
        public static void Main(string[] args)
        {

            var factory = new CarFlyweightFactory(
                new CarType("black", "bmw", "Poland"),
                new CarType("White", "bmw", "Poland"),
                new CarType("black", "Audi", "Germany"),
                new CarType("Red", "Audi", "Germany")
            );

            var carType1 = new CarType("black", "bmw", "Poland");
            var carType2 = new CarType("yellow", "lada", "UK");

            var car1 = new Car("1234", "me", factory.GetCar(carType1));
            var car2 = new Car("1234", "me", factory.GetCar(carType2));


            car1.DoStuff();
            car2.DoStuff();







            MobilePhone mobile = new Sony();
            mobile = new Sony2022(mobile.Name, mobile);

            mobile = new Sony2023(mobile.Name, mobile);


            //////
            mobile = new SonyThatCanMakeCalls2(mobile.Name);// one of the many differences
                                                            // here is I can use MakeCall() cuz mobile != SonyThatCanMakeCalls
                                                            //////

            var mobThatCalls = new SonyThatCanMakeCalls2(mobile.Name);
            mobThatCalls.MakeCall(); // but here I can
            /////



            var s = mobile.GetPrice();
            var s1 = mobile.GetScreenType();
        }


    }
}
