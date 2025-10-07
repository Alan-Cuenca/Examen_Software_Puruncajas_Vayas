using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using System;

namespace Prueba1PuruncajasVayas.Infrastructure.NotificationChannels
{
    /// <summary>
    /// Implementacion del canal de notificacion por email
    /// SRP: Responsabiliad unica - maneja solo notificaciones por email
    /// OCP: Hereda el canal de notificacion sin modificar codigo existente
    /// LSP: Puede sustituir la interfaz sin alterar el comportamiento
    /// </summary>
    public class EmailNotificationChannelPV : INotificationChannelPV
    {
        public void SendNotificationPV(PaymentPV payment)
        {
            // Simulacion del envio por email
            Console.WriteLine($"[EMAIL] Enviando notificaciones a {payment.UserNamePV}:");
            Console.WriteLine($"  Estado: {(payment.IsSuccessfulPV ? "Exitoso" : "Fallido")}");
            Console.WriteLine($"  Mensaje: {payment.MessagePV}");
            Console.WriteLine();
        }
    }
}
