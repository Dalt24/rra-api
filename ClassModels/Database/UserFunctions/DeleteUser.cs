using api_rra1.ClassModels;
using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database
{
    public class DeleteUser
    {

        public static void DropUserTable()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();

                string stm = @"DROP TABLE IF EXISTS users";

                using var cmd = new MySqlCommand(stm, con);

                cmd.ExecuteNonQuery();
                db.CloseCon();
            }
            else
            {
                System.Console.WriteLine("Failed to Drop Table");
            }
        }


    }
}