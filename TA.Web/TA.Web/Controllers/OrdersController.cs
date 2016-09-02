using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TA.Business;
using TA.Data;
using TA.Web.Models;

namespace TA.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: All orders
        public JsonResult GetAllOrders()
        {

            var result = new OrderBusinessManager().GetOrders();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //GET: Order by Id
        public JsonResult GetOrderById(string id)
        {
            using (OrderDBContext contextObj = new OrderDBContext())
            {
                var orderId = Convert.ToInt32(id);
                var getOrderById = contextObj.order.Find(orderId);
                return Json(getOrderById, JsonRequestBehavior.AllowGet);
            }
        }

        public void AddOrder(Order order)
        {
            new OrderBusinessManager().AddOrder(order);
        }
        // Delete book
        public string DeleteOrder(string orderId)
        {

            if (!String.IsNullOrEmpty(orderId))
            {
                try
                {
                    int _orderId = Int32.Parse(orderId);
                    using (OrderDBContext contextObj = new OrderDBContext())
                    {
                        var _order = contextObj.order.Find(_orderId);
                        contextObj.order.Remove(_order);
                        contextObj.SaveChanges();
                        return "Selected order record deleted sucessfully";
                    }
                }
                catch (Exception)
                {
                    return "Order details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}