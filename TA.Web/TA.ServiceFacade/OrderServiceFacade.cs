﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data;

namespace TA.ServiceFacade
{
    public class OrderServiceFacade
    {
        WebServiceGenericConnector<Order> service = new WebServiceGenericConnector<Order>();

        public bool AddOrder(Order order)
        {
            service.Resource = "api/Orders/";
            service.PostData(order);

            return true;
        }
    }
}
