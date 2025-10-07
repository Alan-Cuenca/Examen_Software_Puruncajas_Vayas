
using Prueba1PuruncajasVayas.Application.Services;
using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using Prueba1PuruncajasVayas.Infrastructure.NotificationChannels;
using Prueba1PuruncajasVayas.Infrastructure.PaymentMethods;
using System;

namespace Prueba1PuruncajasVayas
{
    /// <summary>
    /// programa principal 
    /// Implementado con arquitectura limpia (Clean Architecture) y principios SOLID
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("    Procesamiento del metodo de pago");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            // Iicializamos los datos de los pagos internamente
            PaymentPV[] paymentsPV = InitializePaymentDataPV();

            // Procesa cada pago con los difertentes metodos y canales de notificacion
            // implementados en la infraestructura
            ProcessPaymentsPV(paymentsPV);

            Console.WriteLine("===========================================");
            Console.WriteLine("    Todos los pagos procesados");
            Console.WriteLine("===========================================");
            Console.ReadKey();
        }


        /// Inicializa los datos de los pagos
        /// SRP: Responsabilidad unica - solo inicializa datos

        private static PaymentPV[] InitializePaymentDataPV()
        {
            PaymentPV[] payments = new PaymentPV[3];

            payments[0] = new PaymentPV("Juan Vayas", 250.50m, "Tarjeta de credito");
            payments[1] = new PaymentPV("Jorge Sailema", 320.75m, "Efectivo");
            payments[2] = new PaymentPV("Alan Cuenca", 500.00m, "Transferencia bancaria");

            return payments;
        }

        /// <summary>
        /// Procesa los pagos utilizando diferentes metodos y canales de notificacion
        /// DIP: Inyeccion de dependencias - depende de abstracciones
        /// OCP: Se puede extender con nuevos metodos y canales sin modificar 
        /// codigo existente
        /// </summary>
        private static void ProcessPaymentsPV(PaymentPV[] payments)
        {
            // Primero procesa el pago: Tarjeta de credito con notificacion por email
            ProcessSinglePaymentPV(
                payments[0],
                new CreditCardPaymentMethodPV(),
                new INotificationChannelPV[] { new EmailNotificationChannelPV() }
            );

            // Se procesa el pago : Efectivo con notificaciones por SMS y Push
            ProcessSinglePaymentPV(
                payments[1],
                new CashPaymentMethodPV(),
                new INotificationChannelPV[]
                {
                    new SmsNotificationChannelPV(),
                    new PushNotificationChannelPV()
                }
            );

            // Procesa el pago Transferencia bancaria con notificaciones
            // por email, SMS y Push
            ProcessSinglePaymentPV(
                payments[2],
                new BankTransferPaymentMethodPV(),
                new INotificationChannelPV[]
                {
                    new EmailNotificationChannelPV(),
                    new SmsNotificationChannelPV(),
                    new PushNotificationChannelPV()
                }
            );
        }

        /// <summary>
        /// Procesa un solo pago con el metodo y canales de notificacion especificados
        /// DIP: Inyeccion de dependencias - depende de abstracciones
        /// </summary>
        private static void ProcessSinglePaymentPV(
            PaymentPV payment,
            IPaymentMethodPV paymentMethod,
            INotificationChannelPV[] notificationChannels)
        {
            // Crea el servicio de procesamiento con las dependencias inyectadas
            PaymentProcessorServicePV processorService = new PaymentProcessorServicePV(
                paymentMethod,
                notificationChannels
            );

            // Procesa el pago y envia las notificaciones
            processorService.ProcessAndNotifyPV(payment);

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
        }
    }
}