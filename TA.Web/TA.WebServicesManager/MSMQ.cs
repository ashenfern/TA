using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using TA.Data;

namespace TA.WebServicesManager
{
    public class MSMQ : IQueue
    {
        public void Enqueue(Order order, string queueName)
        {
            // check if queue exists, if not create it
            MessageQueue msMq = null;
            if (!MessageQueue.Exists(queueName))
            {
                msMq = MessageQueue.Create(queueName);
            }
            else
            {
                msMq = new MessageQueue(queueName);
            }

            try
            {
                msMq.Send(order);
            }
            catch (MessageQueueException ee)
            {
                Console.Write(ee.ToString());
            }
            catch (Exception eee)
            {
                Console.Write(eee.ToString());
            }
            finally
            {
                msMq.Close();
            }
            //Console.WriteLine("Message sent ......");
        }

        public List<Order> Dequeue(string queueName)
        {
            MessageQueue msMq = new MessageQueue(queueName);
            List<Order> orderList = new List<Order>();

            try
            {
                msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(Order) });

                // Populate an array with copies of all the messages in the queue.
                Message[] msgs = msMq.GetAllMessages();

                foreach (var item in msgs)
                {
                    var message = (Order)msMq.Receive().Body;
                    orderList.Add(message);
                }

                return orderList;

                // Console.WriteLine(message.Body.ToString());
            }
            catch (MessageQueueException ee)
            {

                Console.Write(ee.ToString());

            }

            catch (Exception eee)
            {

                Console.Write(eee.ToString());

            }

            finally
            {

                msMq.Close();

            }

            return new List<Order>();
            //Console.WriteLine("Message received ......");
        }
    }
}
