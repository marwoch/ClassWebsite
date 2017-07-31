using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    /// <summary>
    /// Represents a single product in user's cart
    /// </summary>
    public class CartItem
    {
        public int ProductID { get; set; }

        public short Quantity { get; set; }

        public double PriceWhenAdded { get; set; }

    }
}