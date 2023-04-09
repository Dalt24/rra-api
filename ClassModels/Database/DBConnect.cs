using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database
{
    public class DBConnect
    {
        private MySqlConnection? connection;
        private string? server;
        private string? database;
        private string? port;
        private string? userName;
        private string? password;

        public DBConnect()
        {
            DBinit();
        }


        private void DBinit()
        {
            server = "ckshdphy86qnz0bj.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "ariaudu1us0n6inp";
            port = "3306";
            userName = "ukh0yuwum37t36dn";
            password = "	lzrb32s53powqdhx";

            string cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
            connection = new MySqlConnection(cs);
        }

        public bool OpenCon()
        {
            try
            {
                connection?.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("Failed to Connect");
                }
                else if (ex.Number == 1045)
                {
                    System.Console.WriteLine("Invalid User/Pass");
                }
            }
            return false;
        }

        public bool CloseCon()
        {
            try
            {
                connection?.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return false;
        }

        public MySqlConnection? GetCon()
        {
            return connection;
        }

    }
}


