namespace Prueba1PuruncajasVayas.Domain.Entities
{
    /// <summary>
    /// La clase de la entidad de pago con informacion basica
    /// SRP: Una sola responsabilidad
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