using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class CartSummary: ViewComponent
    {
        private readonly Cart _cart;
 
        public CartSummary(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke() => View(_cart);
    }
}
