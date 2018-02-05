using System;
using System.Collections.Generic;

namespace Cities_console
{
    public class Data
    {
        private List<City> cities;
        private Dictionary<int, Region> regions;
        private Dictionary<int, List<City>> citiesByRegion;

        public Data()
        {
            this.cities = new List<City>();
            this.regions = new Dictionary<int, Region>();
            this.citiesByRegion = new Dictionary<int, List<City>>();
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
            citiesByRegion[city.getRegionUID()].Add(city);
            cities.Add(city);
        }


        //MARK: - Getters
        public List<City> getCities() {
            return cities;
        }

        public Dictionary<int, Region> getRegions()
        {
            return regions;
        }

        public List<City> getCitiesForRegion(int uid)
        {
            if(citiesByRegion.ContainsKey(uid)) {
                return citiesByRegion[uid];    
            }
            return null;
        }

    }
}
