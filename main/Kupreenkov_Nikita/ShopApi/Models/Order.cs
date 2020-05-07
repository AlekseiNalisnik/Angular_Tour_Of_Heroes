using System;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime PlacedDate { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime PaidDate { get; set; }

        public Cart Cart { get; set; }
    }
}
