using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCards
{
    abstract class CreditCard
    {
        protected string cardType;
        protected int creditLimit;
        protected int annualCharge;
        public abstract string CardType { get; }

        public CreditCard(int creditLimit, int annualCharge)
        {
            this.creditLimit = creditLimit;
            this.annualCharge = annualCharge;
        }

        public int CreditLimit { get { return creditLimit; } set { creditLimit = value; } }
        public int AnnualCharge { get { return annualCharge; } set { annualCharge = value; } }
    }

    class MoneyBackCreditCard : CreditCard
    {
        public MoneyBackCreditCard(int creditLimit, int annualCharge) : base (creditLimit, annualCharge)
        {
            cardType = "MoneyBack";
        }

        public override string CardType { get { return cardType; } }
    }

    class TitaniumCreditCard : CreditCard
    {
        public TitaniumCreditCard(int creditLimit, int annualCharge) : base(creditLimit, annualCharge)
        {
            cardType = "Titanium";
        }

        public override string CardType { get { return cardType; } }
    }

    class DarkEditionCreditCard : CreditCard
    {
        public DarkEditionCreditCard(int creditLimit, int annualCharge) : base(creditLimit, annualCharge)
        {
            cardType = "DarkEdition";
        }

        public override string CardType { get { return cardType; } }
    }

    abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }

    class MoneyBackFactory : CardFactory
    {
        private int creditLimit;
        private int annualCharge;

        public MoneyBackFactory(int creditLimit, int annualCharge)
        {
            this.creditLimit = creditLimit;
            this.annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new MoneyBackCreditCard(creditLimit, annualCharge);
        }
    }

    class TitaniumFactory : CardFactory
    {
        private int creditLimit;
        private int annualCharge;

        public TitaniumFactory(int creditLimit, int annualCharge)
        {
            this.creditLimit = creditLimit;
            this.annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new TitaniumCreditCard(creditLimit, annualCharge);
        }
    }

    class DarkEditionFactory : CardFactory
    {
        private int creditLimit;
        private int annualCharge;

        public DarkEditionFactory(int creditLimit, int annualCharge)
        {
            this.creditLimit = creditLimit;
            this.annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new DarkEditionCreditCard(creditLimit, annualCharge);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CardFactory factory = null;
            Console.Write("Enter the card type you would like to visit: ");
            string card = Console.ReadLine();

            switch(card.ToLower())
            {
                case "moneyback":
                    factory = new MoneyBackFactory(5000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumFactory(10000, 500);
                    break;
                case "darkedition":
                    factory = new DarkEditionFactory(7500, 200);
                    break;
                default:
                    break;

            }

            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("\nYour card details are below: \n");
            Console.WriteLine("Card type: {0} \nCredit limit: {1} \nAnnual charge: {2}", creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);

            Console.ReadLine();
        }
    }
}
