using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using System;

namespace Prueba1PuruncajasVayas.Application.Services
{
    /// <summary>
    /// El procesador de pagos maneja el flujo de los procesamientos de los pagos
    /// y las notificaciones.
    /// SRP: Una sola responsabilidad - maneja el flujo de pagos y notificaciones
    /// </summary>
    public class PaymentProcessorServicePV
    {
        private readonly IPaymentMethodPV _paymentMethodPV;
        private readonly INotificationChannelPV[] _notificationChannelsPV;

        /// <summary>
        /// Constructor con inyeccion de dependencias
        /// DIP: Principio de inversion de dependencias - depende de abstracciones
        /// </summary>

        public PaymentProcessorServicePV(
            IPaymentMethodPV paymentMethod, 
            INotificationChannelPV[] notificationChannels)
        {
            _paymentMethodPV = paymentMethod;
            _notificationChannelsPV = notificationChannels;
        }

        /// <summary>
        /// Procesa el pago y notifica a traves de todos los canales configurados
        /// </summary>
        public void ProcessAndNotifyPV(PaymentPV payment)
        {
            // Proceso de pago
            PaymentPV processedPayment = _paymentMethodPV.ProcessPaymentPV(payment);

            // Despliege del resumen del pago
            DisplayPaymentSummaryPV(processedPayment);

            // Envia las notificaciones
            NotifyAllChannelsPV(processedPayment);
        }

        /// <summary>
        /// Despliega un resumen en la consola
        /// </summary>
        private void DisplayPaymentSummaryPV(PaymentPV payment)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         PAYMENT SUMMARY");
            Console.WriteLine("========================================");
            Console.WriteLine($"User:          {payment.UserNamePV}");
            Console.WriteLine($"Amount:        ${payment.AmountPV:F2}");
            Console.WriteLine($"Payment Type:  {payment.PaymentTypePV}");
            Console.WriteLine($"Status:        {(payment.IsSuccessfulPV ? "SUCCESS" : "FAILED")}");
            Console.WriteLine($"Message:       {payment.MessagePV}");
            Console.WriteLine("========================================");
            Console.WriteLine();
        }

        /// <summary>
        /// Envia notificaciones a traves de todos los canales configurados
        /// </summary>
        private void NotifyAllChannelsPV(PaymentPV payment)
        {
            Console.WriteLine("Sending notifications...");
            Console.WriteLine();

            for (int i = 0; i < _notificationChannelsPV.Length; i++)
            {
                _notificationChannelsPV[i].SendNotificationPV(payment);
            }
        }
    }
}