using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;


namespace Cities_console {
    class MainClass {
        
        public static void Main(string[] args) {
            Data data = new Data();
            String path = "./db/Miasta.mdb";
            String password = "";

            DatabaseConnection dbConn = new DatabaseConnection(path, password);
            if (dbConn.Connect()) {
                Console.WriteLine("DB connection established.");

                DataTable regionsTable = dbConn.Execute("SELECT * FROM `regions`");
                if (regionsTable != null) {
                    foreach(DataRow row in regionsTable.Rows) {
                        int regionID = (int)row["ID"];
                        String name = row["Wojewodztwo"].ToString();
                        Region region = new Region(name, regionID);
                        data.addRegion(regionID, region);
                    }
                }

                DataTable citiesTable = dbConn.Execute("SELECT * FROM `city`");
                if (citiesTable != null) {
                    foreach (DataRow row in citiesTable.Rows) {
                        int cityID = (int)row["ID"];
                        String name = row["Miasto"].ToString();
                        Double lon = (Double)row["Dl"];
                        Double lat = (Double)row["Szer"];
                        int regionID = (int)row["ID_woj"];

                        City city = new City(name, cityID, lon, lat, data.getRegion(regionID));
                        data.addCity(city);
                    }
                }

                //TODO do smth with cities and regions in 'data'.
                //Searching for cities in given region.
                int userGivenRegionID = 3;
                List<City> citiesOfRegion = data.getCitiesForRegion(userGivenRegionID);
                foreach(City city in citiesOfRegion) {
                    Console.WriteLine(city.getName());
                }


            }
        }
    }
}
