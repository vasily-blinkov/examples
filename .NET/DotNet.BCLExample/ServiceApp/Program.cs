using System;
using DotNet.BCLExample.ServiceLib.Abstractions;
using DotNet.BCLExample.ServiceLib.Listeners;

namespace DotNet.BCLExample.ServiceApp
{
    class Program
    {
        private static IListener listener = new FileSystemListener();
        private static bool running = true;

        static void Main()
        {
            listener.BeginListening();
            SubscribeApplicatoinClose();

            while (running)
            {
            }
        }

        private static void SubscribeApplicatoinClose()
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ApplicationClose;
            //AppDomain.CurrentDomain.DomainUnload += CurrentDomain_ApplicationClose;
            Console.CancelKeyPress += CurrentDomain_ApplicationClose;
        }

        private static void UnSubscribeApplicationClose()
        {
            AppDomain.CurrentDomain.ProcessExit -= CurrentDomain_ApplicationClose;
            //AppDomain.CurrentDomain.DomainUnload -= CurrentDomain_ApplicationClose;
            Console.CancelKeyPress -= CurrentDomain_ApplicationClose;
        }

        private static void CurrentDomain_ApplicationClose(object sender, EventArgs e)
        {
            UnSubscribeApplicationClose();
            listener.EndListening();
            running = false;
            Console.WriteLine("CurrentDomain_ApplicationClose"); Console.ReadKey();
        }
    }
}
