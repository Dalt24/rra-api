using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.TherapistFunctions
{
    public class ReadTherapist
    {
        public static List<Therapist> ReadAllTherapists()
        {
            List<Therapist> allTherapists = new List<Therapist>();
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();
                string stm = "SELECT * from Therapists";
                using var cmd = new MySqlCommand(stm, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                // therapistID, firstName, lastName, availability, emailAddress, therapistPassword, isAdmin
                while (reader.Read())
                {
                    allTherapists.Add(new Therapist() { therapistID = reader.GetString(0), firstName = reader.GetString(1), lastName = reader.GetString(2), availability = reader.GetString(3), emailAddress = reader.GetString(4), therapistPassword = reader.GetString(5), isAdmin = reader.GetString(6), isTherapist = reader.GetString(7) });
                }
                db.CloseCon();
                return allTherapists;
            }
            else
            {
                return new List<Therapist>();
            }
        }
    }
}