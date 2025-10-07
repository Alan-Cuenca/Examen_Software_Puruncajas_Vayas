using Prueba1PuruncajasVayas.Domain.Entities;

namespace Prueba1PuruncajasVayas.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para los metodos de pago
    /// OCP: Abierto para extension, cerrado para modificacion
    /// ISP: Interfaz segregada - interfaces especificas para cada metodo de pago
    /// </summary>
    public interface IPaymentMethodPV
    {

        /// Procesa el metodo de pago y retorna el resultado

        PaymentPV ProcessPaymentPV(PaymentPV payment);
    }
}