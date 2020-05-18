using System;
using System.ComponentModel.DataAnnotations;
using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Infrastructure.Entities
{
    public class Order : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime PlacedDate { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime PaidDate { get; set; }

        public Cart Cart { get; set; }
    }
}
