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

        public static void DeleteUserr(string id)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                // string stm = @"INSERT INTO Users(UserID, firstName, lastName, availability, emailAddress, UserPassword, isAdmin, isUser) VALUES(@UserID, @firstName, @lastName, @availability, @emailAddress, @UserPassword, @isAdmin, @isUser)";
                string stm = @"DELETE from users WHERE userID =@id";
                MySqlConnection? con = db.GetCon();
                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                System.Console.WriteLine("Failed to Save User");
            }
            db.CloseCon();
        }
    }
}