using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;

namespace Prueba1PuruncajasVayas.Infrastructure.PaymentMethods
{
    /// <summary>
    /// Implementacion del metodo de pago de la transferencia bancaria
    /// SRP: Una sola responsabilidad - maneja solo los pagos por transferencia bancaria
    /// OCP: Hereda el metodo de pago sin modidicar codigo existente
    /// LSP: Puede ser sustituida por la interfaz sin alterar el comportamiento
    /// </summary>
    public class BankTransferPaymentMethodPV : IPaymentMethodPV
    {
        public PaymentPV ProcessPaymentPV(PaymentPV payment)
        {
            // Simulacion de la logica de procesamiento de pagos por transferencia bancaria
            payment.IsSuccessfulPV = true;
            payment.MessagePV = $"Transferencia bancaria de ${payment.AmountPV} procesada con exito {payment.UserNamePV}";

            return payment;
        }
    }
}