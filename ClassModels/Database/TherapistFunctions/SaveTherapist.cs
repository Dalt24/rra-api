using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.TherapistFunctions
{
    public class SaveTherapist
    {
        public static void CreateTherapistTable()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();

                // , isAdmin TEXT, isTherapist TEXT
                string stm = @"CREATE TABLE therapists(therapistID TEXT, firstName TEXT, lastName TEXT, availability TEXT, emailAddress TEXT, therapistPassword TEXT, isAdmin TEXT, isTherapist TEXT)";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();
            }
            db.CloseCon();
        }
        public static void CreateTherapist(Therapist myTherapist)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                // , isAdmin, isTherapist (), @isAdmin, @isTherapist
                MySqlConnection? con = db.GetCon();
                string stm = @"INSERT INTO therapists(therapistID, firstName, lastName, availability, emailAddress, therapistPassword, isAdmin, isTherapist) VALUES(@therapistID, @firstName, @lastName, @availability, @emailAddress, @therapistPassword, @isAdmin, @isTherapist)";
                using var cmd = new MySqlCommand(stm, con);
                Console.WriteLine(myTherapist.availability);
                Console.WriteLine(myTherapist.firstName);
                cmd.Parameters.AddWithValue("@therapistID", myTherapist.therapistID);
                cmd.Parameters.AddWithValue("@firstName", myTherapist.firstName);
                cmd.Parameters.AddWithValue("@lastName", myTherapist.lastName);
                cmd.Parameters.AddWithValue("@availability", myTherapist.availability);
                cmd.Parameters.AddWithValue("@emailAddress", myTherapist.emailAddress);
                cmd.Parameters.AddWithValue("@therapistPassword", myTherapist.therapistPassword);
                cmd.Parameters.AddWithValue("@isAdmin", myTherapist.isAdmin);
                cmd.Parameters.AddWithValue("@isTherapist", myTherapist.isTherapist);
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