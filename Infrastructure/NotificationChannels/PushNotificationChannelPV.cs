using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using System;

namespace Prueba1PuruncajasVayas.Infrastructure.NotificationChannels
{
    /// <summary>
    /// Implementacion del canal de notificacion por notificaciones push
    /// SRP: Responsabilidad unica - maneja solo notificaciones push
    /// OCP: Extensible para nuevos canales sin modificar codigo existente
    /// LSP: Puede sustituir la interfaz sin alterar el comportamiento
    /// </summary>
    public class PushNotificationChannelPV : INotificationChannelPV
    {
        public void SendNotificationPV(PaymentPV payment)
        {
            // Simulacion del envio de notifiaciones por notis push
            Console.WriteLine($"[PUSH] Enviando notificacion a  {payment.UserNamePV}:");
            Console.WriteLine($"  Estado: {(payment.IsSuccessfulPV ? "Exitoso" : "Fallido")}");
            Console.WriteLine($"  Mensaje: {payment.MessagePV}");
            Console.WriteLine();
        }
    }
}

