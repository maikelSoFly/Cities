using System;
using System.Data;
using System.Data.OleDb;


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

                DataTable table = dbConn.execute("SELECT * FROM `myTable`");
                if(table != null) {
                    // Do smth with table...
                    Console.WriteLine(table.ToString());
                }

            }

        }
    }
}
