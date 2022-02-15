using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Structural
{
    public class CarType
    {
        public string Color;
        public string Model;
        public string Manufacturer;

        public CarType(string color, string model, string manufacturer)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
        }        
    }

    public class Car
    {
        public string Vin;
        public string Owner;
        public CarType carType;

        public Car(string vin, string owner, CarType carType)
        {
            Vin = vin;
            Owner = owner;
            this.carType = carType;
        }

        public void DoStuff()
        {
            Console.WriteLine($"This car has {this.carType.Color} color, {this.carType.Model} model, {this.carType.Manufacturer} manuf, vin:{this.Vin} and owner:{this.Owner}");
        }

    }

    /// <summary>
    /// Легковес aka кэш
    /// goal - space optimization
    /// </summary>
    public class CarFlyweightFactory
    {
        private List<CarType> cars = new List<CarType>();

        public CarFlyweightFactory(params CarType[] args)
        {
            foreach (var item in args)
            {
                cars.Add(item);
            }
        }

        public CarType GetCar(CarType someCar)
        {
            if (cars.Where(x => x.Manufacturer == someCar.Manufacturer && x.Model == someCar.Model && x.Color == someCar.Color).Any())
                return this.cars.Where(x => x.Manufacturer == someCar.Manufacturer && x.Model == someCar.Model && x.Color == someCar.Color).First();
            else
            {
                cars.Add(someCar);
                return cars[cars.Count - 1];
            }
        }
    }


    ///var 2

    public class FormatText
    {
        string rawText;
        private List<TextRange> ranges = new List<TextRange>();

        public FormatText(string rawText)
        {
            this.rawText = rawText;
        }

        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange(start, end);
            ranges.Add(range);
            return range;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < rawText.Length; i++)
            {
                var ch = rawText[i];
                foreach (var item in ranges)
                {
                    if (item.Covers(i) && item.Capitalize)
                        ch = char.ToUpper(ch);
                }
                sb.Append(ch);
            }
            return sb.ToString();
        }

        public class TextRange
        {

            public int Start, End;

            public bool Capitalize, Narrowed;

            public TextRange(int start, int end)
            {
                Start = start;
                End = end;
            }

            public bool Covers(int pos)
            {
                return pos >= Start && pos <= End;
            }

        }

        //var bf = new FormatText("Its my life my rules");
        //bf.GetRange(7, 11).Capitalize = true;
        //    System.Console.WriteLine(bf);

    }
}
