using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using System;

namespace Prueba1PuruncajasVayas.Infrastructure.NotificationChannels
{
    /// <summary>
    /// Implementacion del canal de notificacion por email
    /// SRP: Responsabiliad unica - maneja solo notificaciones por email
    /// OCP: Extensible para nuevos canales sin modificar codigo existente
    /// LSP: Puede sustituir la interfaz sin alterar el comportamiento
    /// </summary>
    public class EmailNotificationChannelPV : INotificationChannelPV
    {
        public void SendNotificationPV(PaymentPV payment)
        {
            // Simulacion del envio por email
            Console.WriteLine($"[EMAIL] Sending notification to {payment.UserNamePV}:");
            Console.WriteLine($"  Status: {(payment.IsSuccessfulPV ? "SUCCESS" : "FAILED")}");
            Console.WriteLine($"  Message: {payment.MessagePV}");
            Console.WriteLine();
        }
    }
}
