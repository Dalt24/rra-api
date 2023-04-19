using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.TherapistFunctions
{
    public class DeleteTherapist
    {
        public static void DeleteUserr(string id)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                // string stm = @"INSERT INTO Users(UserID, firstName, lastName, availability, emailAddress, UserPassword, isAdmin, isUser) VALUES(@UserID, @firstName, @lastName, @availability, @emailAddress, @UserPassword, @isAdmin, @isUser)";
                string stm = @"DELETE from Therapists WHERE therapistID =@id";
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