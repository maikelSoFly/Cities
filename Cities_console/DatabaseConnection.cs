using System;
using System.Data.OleDb;

namespace Cities_console
{
    public class DatabaseConnection
    {
        private String connectionString;
        private String dbProvider;
        private String dataSourcePath;
        private String persistSecurityInfo;
        private String password;
        private OleDbConnection conn;


        public DatabaseConnection(String sourcePath, String password, 
                                  String provider="Microsoft.Jet.OLEDB.4.0;", 
                                  String securityInfo="True;")
        {
            this.dataSourcePath = sourcePath;
            this.password = password;
            this.dbProvider = provider;
            this.persistSecurityInfo = securityInfo;
            this.conn = new OleDbConnection();
            this.connectionString = @"Provider=" + this.dbProvider +
                                    "Data Source=" + this.dataSourcePath +
                                    "Persist Security Info=" + this.persistSecurityInfo +
                                    "Jet OLEDB:Database Password=" + this.password;
            conn.ConnectionString = this.connectionString;
        }

        //public static void Main() {}

        public Boolean connect() {
            try {
                
                conn.Open();

            }
            catch(Exception e) {
                Console.WriteLine("OleDB connection FAILED.\n\t" + e.Message);
                return false;
            }

            return true;
        }

    }
}
