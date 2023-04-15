using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.TherapistFunctions
{
    public class UpdateTherapist
    {

        public static void ChangeTherapist(string id, Therapist myTherapist)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                // string stm = @"INSERT INTO therapists(therapistID, firstName, lastName, availability, emailAddress, therapistPassword, isAdmin, isTherapist) VALUES(@therapistID, @firstName, @lastName, @availability, @emailAddress, @therapistPassword, @isAdmin, @isTherapist)";
                Console.WriteLine(id);
                string stm = @"UPDATE therapists SET availability=@availability WHERE therapistID =@id";
                MySqlConnection? con = db.GetCon();
                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@availability", myTherapist.availability);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                System.Console.WriteLine("Failed to Save Therapist");
            }
            db.CloseCon();
        }
    }
}