using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data;
using TA.ServiceFacade;

namespace TA.Business
{
    public class OrderBusinessManager
    {
        public void AddOrder(Order order)
        {
            new OrderServiceFacade().AddOrder(order);
        }

        public List<Order> GetOrders()
        {
            return new OrderServiceFacade().GetOrders();
        }
    }
}
