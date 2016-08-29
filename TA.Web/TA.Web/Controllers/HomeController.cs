using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TA.Data;
using TA.Web.Models;

namespace TA.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        // GET: All books
        public JsonResult GetAllBooks()
        {
            using (OrderDBContext contextObj = new OrderDBContext())
            {
                var bookList = contextObj.order.ToList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Book by Id
        public JsonResult GetBookById(string id)
        {
            using (OrderDBContext contextObj = new OrderDBContext())
            {
                var bookId = Convert.ToInt32(id);
                var getBookById = contextObj.order.Find(bookId);
                return Json(getBookById, JsonRequestBehavior.AllowGet);
            }
        }
        //Update Book
        public string UpdateBook(Order book)
        {
            if (book != null)
            {
                using (OrderDBContext contextObj = new OrderDBContext())
                {
                    int bookId = Convert.ToInt32(book.Id);
                    Order _book = contextObj.order.Where(b => b.Id == bookId).FirstOrDefault();
                    _book.Title = book.Title;
                    _book.Author = book.Author;
                    _book.Publisher = book.Publisher;
                    _book.Isbn = book.Isbn;
                    contextObj.SaveChanges();
                    return "Book record updated successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Add book
        public string AddBook(Order book)
        {
            if (book != null)
            {
                using (OrderDBContext contextObj = new OrderDBContext())
                {
                    contextObj.order.Add(book);
                    contextObj.SaveChanges();
                    return "Book record added successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Delete book
        public string DeleteBook(string bookId)
        {

            if (!String.IsNullOrEmpty(bookId))
            {
                try
                {
                    int _bookId = Int32.Parse(bookId);
                    using (OrderDBContext contextObj = new OrderDBContext())
                    {
                        var _book = contextObj.order.Find(_bookId);
                        contextObj.order.Remove(_book);
                        contextObj.SaveChanges();
                        return "Selected book record deleted sucessfully";
                    }
                }
                catch (Exception)
                {
                    return "Book details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}