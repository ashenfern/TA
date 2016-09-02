using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data;
using TA.WebServicesManager;

namespace Technical.Assesment.WindowsServiceDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager(new MSMQ(), new OrderDBContext());

            //TODO Get these from the config
            const string orderQueue = @".\private$\Order_Queue";
            const string emailQueue = @".\private$\Email_Queue";

            List<Order> orderMessageList = orderManager.ReceiveMessageFromQueue(orderQueue);
            List<Order> emailMessageList = orderManager.ReceiveMessageFromQueue(emailQueue);


            Console.WriteLine("------------------------Order Queue Data----------------");
            Console.WriteLine(String.Format("{0} orders needs to be processed", orderMessageList.Count));
            foreach (var orderMessage in orderMessageList)
            {
                Console.WriteLine(String.Format("Order Description : {0}, Order Customer Name : {1}", orderMessage.Description, orderMessage.CustomerName));
            }

            Console.WriteLine("------------------------Email Queue Data----------------");
            Console.WriteLine(String.Format("{0} emails needs to be send", orderMessageList.Count));
            foreach (var emailMessage in emailMessageList)
            {
                Console.WriteLine(String.Format("Order Description : {0}, Order Customer Name : {1}", emailMessage.Description, emailMessage.CustomerName));
            }

            Console.ReadLine();
        }
    }
}
