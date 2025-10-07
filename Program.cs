using Prueba1PuruncajasVayas.Application.Services;
using Prueba1PuruncajasVayas.Domain.Entities;
using Prueba1PuruncajasVayas.Domain.Interfaces;
using Prueba1PuruncajasVayas.Infrastructure.NotificationChannels;
using Prueba1PuruncajasVayas.Infrastructure.PaymentMethods;
using System;

namespace Prueba1PuruncajasVayas
{
    /// <summary>
    /// Main program entry point
    /// Demonstrates Clean Architecture with SOLID principles
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("    PAYMENT PROCESSING SYSTEM - PV");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            // Initialize payment data internally
            PaymentPV[] paymentsPV = InitializePaymentDataPV();

            // Process each payment with different configurations
            ProcessPaymentsPV(paymentsPV);

            Console.WriteLine("===========================================");
            Console.WriteLine("    ALL PAYMENTS PROCESSED");
            Console.WriteLine("===========================================");
            Console.ReadKey();
        }

        /// <summary>
        /// Initializes payment data internally (no console input)
        /// </summary>
        private static PaymentPV[] InitializePaymentDataPV()
        {
            PaymentPV[] payments = new PaymentPV[3];

            payments[0] = new PaymentPV("John Smith", 150.50m, "Credit Card");
            payments[1] = new PaymentPV("Maria Garcia", 320.75m, "PayPal");
            payments[2] = new PaymentPV("Robert Johnson", 500.00m, "Bank Transfer");

            return payments;
        }

        /// <summary>
        /// Processes all payments with different payment methods and notification channels
        /// DIP: Depends on abstractions, not concrete implementations
        /// OCP: Can add new payment methods and notifications without modifying this code
        /// </summary>
        private static void ProcessPaymentsPV(PaymentPV[] payments)
        {
            // Process first payment: Credit Card with Email notification
            ProcessSinglePaymentPV(
                payments[0],
                new CreditCardPaymentMethodPV(),
                new INotificationChannelPV[] { new EmailNotificationChannelPV() }
            );

            // Process second payment: PayPal with SMS and Push notifications
            ProcessSinglePaymentPV(
                payments[1],
                new PayPalPaymentMethodPV(),
                new INotificationChannelPV[]
                {
                    new SmsNotificationChannelPV(),
                    new PushNotificationChannelPV()
                }
            );

            // Process third payment: Bank Transfer with all notification channels
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
        /// Processes a single payment using dependency injection
        /// DIP: Dependencies injected through constructor
        /// </summary>
        private static void ProcessSinglePaymentPV(
            PaymentPV payment,
            IPaymentMethodPV paymentMethod,
            INotificationChannelPV[] notificationChannels)
        {
            // Create service with injected dependencies
            PaymentProcessorServicePV processorService = new PaymentProcessorServicePV(
                paymentMethod,
                notificationChannels
            );

            // Process and notify
            processorService.ProcessAndNotifyPV(payment);

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
        }
    }
}