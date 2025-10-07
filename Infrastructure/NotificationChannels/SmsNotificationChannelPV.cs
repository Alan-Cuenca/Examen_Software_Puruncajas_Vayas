
using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using System;

namespace Prueba1PuruncajasVayas.Infrastructure.NotificationChannels
{
    /// <summary>
    /// Implementacion de las notificaciones por SMS
    /// SRP: Principio de responsabilidad unica - maneja solo notificaciones por SMS
    /// OCP: Extensible para nuevos canales sin modificar el codigo existente
    /// LSP: Puede sustituir la interfaz sin alterar su comportamiento
    /// </summary>
    public class SmsNotificationChannelPV : INotificationChannelPV
    {
        public void SendNotificationPV(PaymentPV payment)
        {
            // Simulacion de el envio de notificaciones por SMS
            Console.WriteLine($"[SMS] Enviando notificacion a {payment.UserNamePV}:");
            Console.WriteLine($"  Estado: {(payment.IsSuccessfulPV ? "Exitoso" : "Fallido")}");
            Console.WriteLine($"  Mensaje: {payment.MessagePV}");
            Console.WriteLine();
        }
    }
}
