using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.WebServicesManager
{
    public class SBQ : IQueue
    {
        public void Enqueue(Data.Order item, string queueName)
        {
            throw new NotImplementedException();
        }

        public Data.Order Dequeue(string queueName)
        {
            throw new NotImplementedException();
        }
    }
}
