using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.AppointmentFunctions
{
    public class UpdateAppointment
    {
        public static void ChangeAppointment(string id, Appointment myAppointment)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                // string stm = @"INSERT INTO Appointments(AppointmentID, firstName, lastName, availability, emailAddress, AppointmentPassword, isAdmin, isAppointment) VALUES(@AppointmentID, @firstName, @lastName, @availability, @emailAddress, @AppointmentPassword, @isAdmin, @isAppointment)";
                Console.WriteLine(id);
                string stm = @"UPDATE appointments SET isCanceled=@isCanceled WHERE appointmentID =@id";
                MySqlConnection? con = db.GetCon();
                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@isCanceled", myAppointment.isCanceled);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                System.Console.WriteLine("Failed to Save Appointment");
            }
            db.CloseCon();
        }
    }
}