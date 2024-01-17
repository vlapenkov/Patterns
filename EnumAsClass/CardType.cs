using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumAsClass
{
    public class CardType
    : Enumeration
    {
        public static CardType Amex = new AmexCardType();
        public static CardType Visa = new VisaCardType();
        public static CardType MasterCard = new MasterCardType();


        protected CardType(int id, string name)
            : base(id, name)
        {
        }

        private class AmexCardType : CardType
        {
            public AmexCardType() : base(1, "Amex")
            { }
        }

        private class VisaCardType : CardType
        {
            public VisaCardType() : base(2, "Visa")
            { }
        }

        private class MasterCardType : CardType
        {
            public MasterCardType() : base(3, "MasterCard")
            { }
        }
    }

    public class CardTypeDerived : CardType
    {
        public static CardType Sber = new SberCardType();
        

        public CardTypeDerived(int id, string name)
            : base(id, name)
        {
        }

        

        private class SberCardType : CardTypeDerived
        {
            public SberCardType() : base(5, "Sber")
            { }
        }
    }
}
