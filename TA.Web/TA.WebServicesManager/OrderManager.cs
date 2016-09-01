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
        private OrderDBContext db;
        private IQueue queue;

        public OrderManager(IQueue _queue, OrderDBContext _db)
        {
            queue = _queue;
            db = _db;
        }

        public void AddOrdersQueue(Order order, string queueName)
        {
            queue.Enqueue(order, queueName);
        }

        public IList<Order> GetOrders()
        {
            return db.order.ToList();
        }

        public void AddOrdersToDb(Order order)
        {
            db.order.Add(order);
            db.SaveChanges();
        }

       

    }
}
