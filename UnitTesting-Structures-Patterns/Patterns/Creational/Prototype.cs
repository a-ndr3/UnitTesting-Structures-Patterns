using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Structures_Patterns.Patterns.Creational
{
    public class IdNumber
    {
        public int Id;

        public IdNumber(int id)
        {
            this.Id = id;
        }
    }
    public class MobilePrototype : ICloneable
    {
        public string Screen;
        public string Name;
        public string Description;
        public string Material;
        public IdNumber IdNumber;

        public object Clone()
        {
            MobilePrototype mobile = (MobilePrototype)MemberwiseClone();
            return mobile;
        }

        public object DeepCopy()
        {
            MobilePrototype mobile = (MobilePrototype)MemberwiseClone();
            mobile.IdNumber = new IdNumber(IdNumber.Id);
            return mobile;
        }
    }
}
