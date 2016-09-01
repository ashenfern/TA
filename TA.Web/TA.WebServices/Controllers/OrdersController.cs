using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TA.Data;
using TA.WebServicesManager;

namespace TA.WebServices.Controllers
{
    public class OrdersController : ApiController
    {
        private OrderManager orderManager;

        public OrdersController()
        {
            //Using Unity DI framework to create orderManager. Avoding using new OrderManager(new MSMQ(), new OrderDBContext())
            IUnityContainer container = new UnityContainer();
            container.RegisterType<OrderManager>();
            container.RegisterType<IQueue, SBQ>();
            container.RegisterType<IQueue, MSMQ>();
            container.RegisterType<OrderDBContext, OrderDBContext>();

            orderManager = container.Resolve<OrderManager>();
        }

        // GET api/Orders
        public IList<Order> GetOrders()
        {        
            //return db.order.ToList();
            return orderManager.GetOrders();
        }

        // POST api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Add order to direct Database
            orderManager.AddOrdersToDb(order);

            //TODO Get these from the config
            const string queueOrderName = @".\private$\Order_Queue";
            const string queueEmailName = @".\private$\Email_Queue";

            //Adding order to Order Queue
            orderManager.AddOrdersQueue(order, queueOrderName);
            //Adding order to Email Queue
            orderManager.AddOrdersQueue(order, queueEmailName);

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        #region TODO Commented
        //// GET api/Orders/5
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult GetOrder(int id)
        //{
        //    Order order = db.order.Find(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //}

        // PUT api/Orders/5
        //public IHttpActionResult PutOrder(int id, Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //} 

        // DELETE api/Orders/5
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult DeleteOrder(int id)
        //{
        //    Order order = db.order.Find(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    db.order.Remove(order);
        //    db.SaveChanges();

        //    return Ok(order);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool OrderExists(int id)
        //{
        //    return db.order.Count(e => e.Id == id) > 0;
        //}
        #endregion
        
    }
}