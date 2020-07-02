using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string Name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);       
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCoutOfREstaurants();
        int Commit();
    }
}
