using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data;

namespace TA.WebServicesManager
{
    public interface IQueue
    {
        void Enqueue(Order item, string QueueName);
        Order Dequeue(string QueueName);
    }
}
