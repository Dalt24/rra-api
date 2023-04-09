using api_rra1.ClassModels;
using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database
{
    public class SaveUser
    {
        public static void CreateUserTable()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();

                string stm = @"CREATE TABLE users(userID TEXT, firstName TEXT, lastName TEXT, emailAddress TEXT, phoneNumber TEXT, userPassword TEXT, isAdmin TEXT, isTherapist TEXT)";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();
            }
            db.CloseCon();
        }
        public string? userID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? emailAddress { get; set; }
        public string? phoneNumber { get; set; }
        public string? userPassword { get; set; }
        public string? isAdmin { get; set; }
        public string? isTherapist { get; set; }
        public static void CreateUser(User myUser)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();
                string stm = @"INSERT INTO users(userID, firstName, lastName, emailAddress, phoneNumber, userPassword, isAdmin, isTherapist) VALUES(@userID, @firstName, @lastName, @emailAddress, @phoneNumber, @userPassword, @isAdmin, @isTherapist)";
                using var cmd = new MySqlCommand(stm, con);

                // @userID, @firstName, @lastName, @emailAddress, @phoneNumber, @userPassword, @isAdmin, @isTherapist
                cmd.Parameters.AddWithValue("@userID", myUser.userID);
                cmd.Parameters.AddWithValue("@firstName", myUser.firstName);
                cmd.Parameters.AddWithValue("@lastName", myUser.lastName);
                cmd.Parameters.AddWithValue("@emailAddress", myUser.emailAddress);
                cmd.Parameters.AddWithValue("@phoneNumber", myUser.phoneNumber);
                cmd.Parameters.AddWithValue("@userPassword", myUser.userPassword);
                cmd.Parameters.AddWithValue("@isAdmin", myUser.isAdmin);
                cmd.Parameters.AddWithValue("@isTherapist", myUser.isTherapist);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                System.Console.WriteLine("failed");
            }
            db.CloseCon();
        }
    }
}
