using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Creational
{
    public class Mobile
    {
        public string Color { get; set; }
        public string Material { get; set; }
        public int Weight { get; set; }
        public int AmountOfScreens { get; set; }
    }

    public interface Builder
    {
        public Builder WithColor(string color);
        public Builder WithMaterial(string material);
        public Builder WithWeight(int weight);
        public Builder WithAmountOfScreens(int amount);
        public Mobile Build();
    }

    public class MobileBuilder : Builder
    {
        public MobileBuilder()
        {

        }
        public Builder Builder { get; }
        public Action<Mobile> Action { get; }

        private MobileBuilder(Builder builder, Action<Mobile> action)
        {
            Builder = builder;
            Action = action;
        }

        public Builder WithAmountOfScreens(int amount)
        {
            return new MobileBuilder(this, mobile => mobile.AmountOfScreens = amount);
        }

        public Builder WithMaterial(string material)
        {
            return new MobileBuilder(this, mobile => mobile.Material = material);
        }

        public Builder WithWeight(int weight)
        {
            return new MobileBuilder(this, mobile => mobile.Weight = weight);
        }

        public Builder WithColor(string color)
        {
            return new MobileBuilder(this, mobile => mobile.Color = color);
        }

        public Mobile Build()
        {
            return GetResult();
        }
        
        private Mobile GetResult()
        {
            if (Builder == null) return new Mobile();

            var mobile = Builder.Build();

            Action.Invoke(mobile);               
            
            return mobile;
        }

    }

    //usage of this version
    //var builder = new MobileBuilder();
    //var b = builder.WithMaterial("sa")
    //    .WithAmountOfScreens(12);


    //var c = b.WithColor("1");
    //var d = b.WithColor("2");

    //System.Console.WriteLine(c.Build().Color);
    //        System.Console.WriteLine(d.Build().Color);

    public class MobileBuilderClassic : Builder
    {
        private Mobile mobile = new Mobile();

        public Builder WithAmountOfScreens(int amount)
        {
            mobile.AmountOfScreens = amount;
            return this;
        }

        public Builder WithMaterial(string material)
        {
            mobile.Material = material;
            return this;
        }

        public Builder WithWeight(int weight)
        {
            mobile.Weight = weight;
            return this;
        }

        public Mobile Build()
        {
            return mobile;
        }

        public Builder WithColor(string color)
        {
            mobile.Color = color;
            return this;
        }
    }

}
