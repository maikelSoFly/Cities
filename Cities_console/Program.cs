using System;
using System.Data.Odbc;


namespace Cities_console
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            String path = "./db/Miasta.mdb";
            DatabaseConnection dbConn = new DatabaseConnection(path, "");
            if (dbConn.connect()) {
                Console.WriteLine("DB connection established.");
            }

        }
    }
}
