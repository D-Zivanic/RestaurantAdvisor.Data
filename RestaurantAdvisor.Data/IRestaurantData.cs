using RestaurantAdvisor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdvisor.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllByName(string name);
        Restaurant GetSingle(int? id);
        Restaurant Update(Restaurant updatedRest);
        Restaurant Create(Restaurant newRest);
        Restaurant Delete(int id);
        int Save();
    }
}
