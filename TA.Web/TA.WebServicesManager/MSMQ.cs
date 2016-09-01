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

        public Order Dequeue(string QueueName)
        {
            throw new NotImplementedException();
        }
    }
}
