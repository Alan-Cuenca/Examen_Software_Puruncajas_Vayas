

using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;

namespace Prueba1PuruncajasVayas.Infrastructure.PaymentMethods
{
    /// <summary>
    /// Implementacion del metodo de pago con tarjeta de credito
    /// SRP: Una sola responsabilidad - maneja solo los pagos con tarjeta de credito
    /// OCP: Hereda el metodo de pago sin modidicar codigo existente
    /// LSP: Puede ser sustituida por la interfaz sin alterar el comportamiento
    /// </summary>
    public class CreditCardPaymentMethodPV : IPaymentMethodPV
    {
        public PaymentPV ProcessPaymentPV(PaymentPV payment)
        {
            // Simulacion la logica de procesamiento de pagos con tarjeta de credito
            payment.IsSuccessfulPV = true;
            payment.MessagePV = $"El pago con tarjeta de credito ${payment.AmountPV} procesado con exito ${payment.UserNamePV}";

            return payment;
        }
    }
}
