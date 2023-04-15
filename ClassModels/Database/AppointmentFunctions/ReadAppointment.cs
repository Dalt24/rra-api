using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.AppointmentFunctions
{
    public class ReadAppointment
    {
        public static List<Appointment> ReadAllAppointments()
        {
            List<Appointment> allAppointments = new List<Appointment>();
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();
                string stm = "SELECT * from appointments";
                using var cmd = new MySqlCommand(stm, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allAppointments.Add(new Appointment() { userID = reader.GetString(0), firstName = reader.GetString(1), lastName = reader.GetString(2), emailAddress = reader.GetString(3), locationAddress = reader.GetString(4), therapistFirstName = reader.GetString(5), therapistLastName = reader.GetString(6), therapistID = reader.GetString(7), appointmentID = reader.GetString(8), appointmentStartDate = reader.GetString(9), appointmentEndDate = reader.GetString(10) });
                }
                db.CloseCon();
                return allAppointments;
            }
            else
            {
                return new List<Appointment>();
            }
        }
    }
}