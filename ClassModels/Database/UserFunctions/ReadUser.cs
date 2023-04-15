using api_rra1.ClassModels;
using api_rra1.ClassModels.Database;
using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database
{
    public class ReadUser
    {
        public static List<User> ReadAllUsers()
        {
            List<User> allUsers = new List<User>();
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();
                string stm = "SELECT * from users";
                using var cmd = new MySqlCommand(stm, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allUsers.Add(new User() { userID = reader.GetString(0), firstName = reader.GetString(1), lastName = reader.GetString(2), emailAddress = reader.GetString(3), phoneNumber = reader.GetString(4), userPassword = reader.GetString(5), isAdmin = reader.GetString(6), isTherapist = reader.GetString(7) });
                }
                db.CloseCon();
                return allUsers;
            }
            else
            {
                return new List<User>();
            }
        }
    }
}