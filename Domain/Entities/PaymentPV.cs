namespace Prueba1PuruncajasVayas.Domain.Entities
{
    /// <summary>
    /// Represents a payment entity with basic information
    /// SRP: Single responsibility - holds payment data only
    /// </summary>
    public class PaymentPV
    {
        public string UserNamePV { get; set; }
        public decimal AmountPV { get; set; }
        public string PaymentTypePV { get; set; }
        public bool IsSuccessfulPV { get; set; }
        public string MessagePV { get; set; }

        public PaymentPV(string userName, decimal amount, string paymentType)
        {
            UserNamePV = userName;
            AmountPV = amount;
            PaymentTypePV = paymentType;
            IsSuccessfulPV = false;
            MessagePV = string.Empty;
        }
    }
}