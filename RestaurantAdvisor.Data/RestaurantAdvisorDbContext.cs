using Microsoft.EntityFrameworkCore;
using RestaurantAdvisor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdvisor.Data
{
    public class RestaurantAdvisorDbContext : DbContext
    {
        public RestaurantAdvisorDbContext(DbContextOptions<RestaurantAdvisorDbContext> options)
            :base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
