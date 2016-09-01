using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data;

namespace TA.WebServicesManager
{
    public class OrderManager
    {
        private OrderDBContext db = new OrderDBContext();

        public IList<Order> GetOrders()
        {
            return db.order.ToList();
        }

        public void AddOrdersToDb(Order order)
        {
            db.order.Add(order);
            db.SaveChanges();
        }

        public void AddOrdersToMSMQ(Order order, string queueName)
        {
            IQueue queue = new MSMQ();

            queue.Enqueue(order,queueName);
        }

    }
}
