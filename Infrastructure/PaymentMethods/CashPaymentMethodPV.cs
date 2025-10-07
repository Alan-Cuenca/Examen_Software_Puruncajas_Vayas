using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;

namespace Prueba1PuruncajasVayas.Infrastructure.PaymentMethods
{
    /// <summary>
    /// Implementacion del metodo de pago con efectivo
    /// SRP: Principio de responsabilidad unica - maneja solo pagos en efectivo
    /// OCP: Hereda el metodo de pago sin modificar codigo existente
    /// LSP: Puede ser sustituida por la interfaz sin alterar el comportamiento
    /// </summary>
    public class CashPaymentMethodPV : IPaymentMethodPV
    {
        public PaymentPV ProcessPaymentPV(PaymentPV payment)
        {
            // Simulacion de la logica de procesamiento de pagos en efectivo
            payment.IsSuccessfulPV = true;
            payment.MessagePV = $"El pago con efectivo ${payment.AmountPV} se proceso con exito {payment.UserNamePV}";

            return payment;
        }
    }
}
