using Microsoft.EntityFrameworkCore;
using RestaurantAdvisor.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAdvisor.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantAdvisorDbContext _db;

        public SqlRestaurantData(RestaurantAdvisorDbContext db)
        {
            _db = db;
        }

        public Restaurant Create(Restaurant newRest)
        {
            _db.Add(newRest);
            return newRest;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetSingle(id);
            if (restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
            }
            return restaurant;

        }

        public IEnumerable<Restaurant> GetAllByName(string name)
        {
            var query = from r in _db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant GetSingle(int? id)
        {
            return _db.Restaurants.Find(id);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public Restaurant Update(Restaurant updatedRest)
        {
            var entity = _db.Restaurants.Attach(updatedRest);
            entity.State = EntityState.Modified;
            return updatedRest;

        }
    }
}
