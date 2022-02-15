using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Structural
{
    //Adding behavior without altering the class itself

    public interface INode
    {
        public string DoSmth();
    }

    public class ScpecificNode1 : INode
    {
        public string DoSmth()
        {
            return "specificNode1";
        }
    }

    public class ScpecificNode2 : INode
    {
        public string DoSmth()
        {
            return "specificNode2";
        }
    }




    public abstract class Decorator : INode
    {
        INode node;

        protected Decorator(INode node)
        {
            this.node = node;
        }

        public virtual string DoSmth()
        {
            if (this.node != null)
            {
                node.DoSmth();
            }

            return default;
        }
    }

    public class SomeDecorator : Decorator
    {
        public SomeDecorator(INode node) : base(node)
        {
        }

        public override string DoSmth()
        {
            return $"SomeDecorator1";
        }
    }

    public class SomeDecorator2 : Decorator
    {
        public SomeDecorator2(INode node) : base(node)
        {
        }

        public override string DoSmth()
        {
            return "SomeDecorator2";
        }
    }


    //var node = new ScpecificNode1();
    //System.Console.WriteLine(node.DoSmth());

    //        var decor1 = new SomeDecorator(node);

    //System.Console.WriteLine(decor1.DoSmth()); 


    //Decorator v2





   public abstract class MobilePhone
    {
        public string Name { get; protected set; }
        public MobilePhone(string name)
        {
            this.Name = name;
        }

        public abstract int GetPrice();

        public abstract string GetScreenType();
        public abstract string GetChargeType();
    }

    public class Samsung : MobilePhone
    {
        public Samsung() : base("Samsung")
        {
        }

        public override string GetChargeType()
        {
            return "Type C";
        }

        public override int GetPrice()
        {
            return 1000;
        }

        public override string GetScreenType()
        {
            return "NormalGlass";
        }
    }

    public class Sony : MobilePhone
    {
        public Sony() : base("Sony")
        {
        }

        public override string GetChargeType()
        {
            return "USB";
        }

        public override int GetPrice()
        {
            return 500;
        }

        public override string GetScreenType()
        {
            return "ProtectedGlass";
        }
    }

    public abstract class MobileDecorator : MobilePhone
    {
        protected MobilePhone mobilePhone;
        protected MobileDecorator(string name, MobilePhone mobilePhone) : base(name)
        {
            this.mobilePhone = mobilePhone;
        }

    }

    public class Sony2022 : MobileDecorator
    {
        public Sony2022(string name, MobilePhone mobilePhone) : base(name, mobilePhone)
        {

        }

        public override string GetChargeType()
        {
           return mobilePhone.GetChargeType();
        }

        public override int GetPrice()
        {
            return 1400;
        }

        public override string GetScreenType()
        {
            return mobilePhone.GetScreenType();
        }
    }

    public class Sony2023 : MobileDecorator
    {
        public Sony2023(string name, MobilePhone mobilePhone) : base(name, mobilePhone)
        {

        }

        public override string GetChargeType()
        {
            return mobilePhone.GetChargeType();
        }

        public override int GetPrice()
        {
            return mobilePhone.GetPrice();
        }

        public override string GetScreenType()
        {
            return "UltraProtected";
        }

    }


    


    public interface PhonesAdds
    {
        public void MakeCall();
    }

   
    public class SonyThatCanMakeCalls2 : MobilePhone, PhonesAdds
    { 
        public SonyThatCanMakeCalls2(string name) : base(name)
        {
           
        }

        public override string GetChargeType()
        {
            return "some wire";
        }

        public override int GetPrice()
        {
            return 10000;
        }

        public override string GetScreenType()
        {
            return "some weird screentype";
        }

        public void MakeCall()
        {
            Console.WriteLine("Making call");
        }
    }

}
