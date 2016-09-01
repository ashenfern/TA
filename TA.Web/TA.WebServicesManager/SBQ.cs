using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data;

namespace TA.WebServicesManager
{
    public class SBQ : IQueue
    {
        public void Enqueue(Order item, string queueName)
        {
            throw new NotImplementedException();
        }

        public Order Dequeue(string queueName)
        {
            throw new NotImplementedException();
        }
    }
}
