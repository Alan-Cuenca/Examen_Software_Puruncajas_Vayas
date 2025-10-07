
using Prueba1PuruncajasVayas.Domain.Entities;

namespace Prueba1PuruncajasVayas.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para los canales de notificacion
    /// SRP: Una sola responsabilidad - maneja solo notificaciones
    /// OCP: Principio de abierto/cerrado -
    /// </summary>
    public interface INotificationChannelPV
    {
        /// Envia una notificacion del resultado del pago
        void SendNotificationPV(PaymentPV payment);
    }
}