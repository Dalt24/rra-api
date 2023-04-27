using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.UserFunctions
{
    public class UpdateUser
    {
        public static void ChangeUser(string id, User myUser)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                // string stm = @"INSERT INTO Users(UserID, firstName, lastName, availability, emailAddress, UserPassword, isAdmin, isUser) VALUES(@UserID, @firstName, @lastName, @availability, @emailAddress, @UserPassword, @isAdmin, @isUser)";
                string stm = @"UPDATE users SET userPassword=@userPassword WHERE userID =@id";
                MySqlConnection? con = db.GetCon();
                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@userPassword", myUser.userPassword);
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