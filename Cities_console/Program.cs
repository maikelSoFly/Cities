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

            DatabaseConnection dbConn = new DatabaseConnection(path, password);
            if (dbConn.Connect())
            {
                Console.WriteLine("DB connection established.");

                DataTable regionsTable = dbConn.Execute("SELECT * FROM `regions`");
                if (regionsTable != null)
                {
                    foreach (DataRow row in regionsTable.Rows)
                    {
                        int regionID = (int)row["ID"];
                        String name = row["Wojewodztwo"].ToString();
                        Region region = new Region(name, regionID);
                        data.addRegion(regionID, region);
                    }
                }

                DataTable citiesTable = dbConn.Execute("SELECT * FROM `city`");
                if (citiesTable != null)
                {
                    foreach (DataRow row in citiesTable.Rows)
                    {
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
                    Console.WriteLine(String.Format("\t{0}. {1}", i, city.getName()));
                    i++;
                }

                int selectedCityIndex = 0;
                while (!(selectedCityIndex > 0 && selectedCityIndex <= citiesOfRegion.Count)) {
                    selectedCityIndex = ReadLine<int>("Select region (int): ");
                }

                City selectedCity = citiesOfRegion[selectedCityIndex-1];
            }
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