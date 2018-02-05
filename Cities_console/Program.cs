using System;
using System.Data;
using System.Collections.Generic;
using System.IO;


namespace Cities_console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Data data = new Data();
            String path = "./db/Miasta.mdb";
            String password = "";

            //DatabaseConnection dbConn = new DatabaseConnection(path, password);
            //if (dbConn.Connect())
            //{
                //Console.WriteLine("DB connection established.");

                //DataTable regionsTable = dbConn.Execute("SELECT * FROM `regions`");
                //if (regionsTable != null)
                //{
                //    foreach (DataRow row in regionsTable.Rows)
                //    {
                //        int regionID = (int)row["ID"];
                //        String name = row["Wojewodztwo"].ToString();
                //        Region region = new Region(name, regionID);
                //        data.addRegion(regionID, region);
                //    }
                //}

                //DataTable citiesTable = dbConn.Execute("SELECT * FROM `city`");
                //if (citiesTable != null)
                //{
                //    foreach (DataRow row in citiesTable.Rows)
                //    {
                //        int cityID = (int)row["ID"];
                //        String name = row["Miasto"].ToString();
                //        Double lon = (Double)row["Dl"];
                //        Double lat = (Double)row["Szer"];
                //        int regionID = (int)row["ID_woj"];

                //        City city = new City(name, cityID, lon, lat, data.getRegion(regionID));
                //        data.addCity(city);
                //    }
                //}

                //For tests only.
                Region reg1 = new Region("Małopolskie", 1);
                Region reg2 = new Region("Małopolskie", 2);
                data.addRegion(1, reg1);
                data.addRegion(2, reg2);
                data.addCity(new City("Kraków", 1, 33.4, 122.4, reg1));
                data.addCity(new City("Katowice", 2, 31.4, 123.4, reg2));
                data.addCity(new City("Sosnowiec", 2, 30.4, 123.3, reg2));


                //TODO do smth with cities and regions in 'data'.
                //Searching for cities in the given region.

                List<City> citiesOfRegion = null;

                while (citiesOfRegion == null)
                {
                    int regID = ReadLine<int>("Region id: ");
                    citiesOfRegion = data.getCitiesForRegion(regID);
                }

                int i = 0;
                foreach (City city in citiesOfRegion)
                {
                    i++;
                    Console.WriteLine(String.Format("\t{0}. {1}", i, city.getName()));
                }

                int selectedCityIndex = 0;
                while (!(selectedCityIndex > 0 && selectedCityIndex <= citiesOfRegion.Count)) {
                    selectedCityIndex = ReadLine<int>("\nSelect city (int): ");
                }

                City selectedCity = citiesOfRegion[selectedCityIndex-1];
                Console.WriteLine(String.Format("\nName: {0}, Longitude: {1}, Latitude: {2}, Region: {3}", selectedCity.getName(), 
                                                selectedCity.getLongitude(), 
                                                selectedCity.getLatitude(), 
                                                selectedCity.getRegion().getName()));
            //}
        }


        //Read from stdin and cast to specified type.
        //  message - print info message about expected input.
        static T ReadLine<T>(String message)
        {
            Console.WriteLine(message);
            try
            {
                string line = Console.ReadLine();
                T convertedValue = (T)Convert.ChangeType(line, typeof(T));

                return convertedValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default(T);
        }
    }
}