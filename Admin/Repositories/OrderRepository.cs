using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Repositories
{
 public class OrderRepository
 {
  public List<Models.Order> GetOrders()
  {
   return new List<Models.Order>
              {
                  new Models.Order { Id = 0, Name = "(odabir)" },
                  new Models.Order { Id = 1, Name = "Broj soba - Rastuće" },
                  new Models.Order { Id = 2, Name = "Broj soba - Padajuće" },
                  new Models.Order { Id = 3, Name = "Cijena - Rastuća" },
                  new Models.Order { Id = 4, Name = "Cijena - Padajuća" },
                  new Models.Order { Id = 5, Name = "Broj odraslih - Rastuće" },
                  new Models.Order { Id = 6, Name = "Broj odraslih - Padajuće" },
                  new Models.Order { Id = 7, Name = "Broj djece - Rastuće" },
                  new Models.Order { Id = 8, Name = "Broj djece - Padajuće" },
              };
  }
 }
}