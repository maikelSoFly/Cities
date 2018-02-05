using System;
using System.Collections.Generic;

namespace Cities_console
{
    public class Data
    {
        private List<City> cities;
        private Dictionary<int, Region> regions;

        public Data()
        {
            this.cities = new List<City>();
            this.regions = new Dictionary<int, Region>();
        }

        public void addRegion(int id, Region region) {
            regions.Add(id, region);
        }

        public Region getRegion(int id) {
            if (regions.ContainsKey(id)) {
                return regions[id];
            } 
            else return null;
        }

        public void addCity(City city) {
            cities.Add(city);
        }
    }
}
