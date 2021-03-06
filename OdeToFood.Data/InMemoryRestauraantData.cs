﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
    public class InMemoryRestauraantData : IRestaurantData
    {


        List<Restaurant> restaurants;

        public InMemoryRestauraantData()
        {
            restaurants = new List<Restaurant>() 
            {
                new Restaurant{ Id=1,Name="معجنات المحبة",Location="الفنادق",Cuisine=CuisineType.Italian},
                new Restaurant{ Id=2,Name="ليالي شرق",Location="المساعدية",Cuisine=CuisineType.Indian},
                new Restaurant{ Id=3,Name="ملك المقلوبة",Location="الشارع العام",Cuisine=CuisineType.Mexican}
            };
        }

        public Restaurant GetById(int id) 
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;

        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if (restaurant !=null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit() 
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant !=null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCoutOfREstaurants()
        {
            return restaurants.Count();
        }
    }
}
