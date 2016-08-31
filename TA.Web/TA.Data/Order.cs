using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        //TODO
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        //TODO
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
        public virtual Item Item { get; set; }
        public  virtual Customer customer { get; set; }
    }
}
