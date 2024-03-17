namespace FactoryMethodPattern
{
    public abstract class PaymentService
    {
        public abstract int charges { get; }
    }

    public class CardPaymentService : PaymentService
    {
        private readonly string _cardNumber;

        public CardPaymentService(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public override int charges => 200;
    }

    public class UPIPaymentService : PaymentService
    {
        private readonly string _upiProvider;
        public UPIPaymentService(string upiProvider)
        {
            _upiProvider= upiProvider;
        }

        public override int charges {
            get
            {
                switch (_upiProvider)
                {
                    case "gpay":
                        return 200;
                    case "phonepay":
                        return 199;
                    default:
                        return 200;
                }
            }
        }
    }

    public abstract class PaymentFactory
    {
        public abstract PaymentService CreatePaymentService();
    }

    public class CardPaymentFactory: PaymentFactory
    {
        private readonly string _cardNumber;
        public CardPaymentFactory(string cardNumber)
        {
            _cardNumber= cardNumber;
        }
        public override PaymentService CreatePaymentService()
        {
            return new CardPaymentService(_cardNumber);
        }
    }

    public class UPIPaymentFactory : PaymentFactory
    {
        private readonly string _upiProvider;
        public UPIPaymentFactory(string upiProvider)
        {
            _upiProvider = upiProvider;
        }
        public override PaymentService CreatePaymentService()
        {
            return new UPIPaymentService(_upiProvider);
        }
    }
}
