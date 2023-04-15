using api_rra1.ClassModels;
using MySql.Data.MySqlClient;

namespace api_rra1.ClassModels.Database.AppointmentFunctions
{
    public class SaveAppointment
    {
        public static void CreateAppointmentTable()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();

                string stm = @"CREATE TABLE appointments(userID TEXT, firstName TEXT, lastName TEXT, emailAddress TEXT, locationAddress TEXT, therapistFirstName TEXT, therapistLastName TEXT, therapistID TEXT, appointmentID TEXT, appointmentStartDate TEXT, appointmentEndDate TEXT, therapyType TEXT, isCanceled TEXT)";
                using var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();
            }
            db.CloseCon();
        }

        public static void CreateAppointment(Appointment myAppointment)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenCon();
            if (isOpen)
            {
                MySqlConnection? con = db.GetCon();
                string stm = @"INSERT INTO appointments(userID, firstName, lastName, emailAddress, locationAddress, therapistFirstName, therapistLastName, therapistID, appointmentID, appointmentStartDate, appointmentEndDate, therapyType, isCanceled) VALUES(@userID, @firstName, @lastName, @emailAddress, @locationAddress, @therapistFirstName, @therapistLastName, @therapistID, @appointmentID, @appointmentStartDate, @appointmentEndDate, @therapyType, @isCanceled)";
                using var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@userID", myAppointment.userID);
                cmd.Parameters.AddWithValue("@firstName", myAppointment.firstName);
                cmd.Parameters.AddWithValue("@lastName", myAppointment.lastName);
                cmd.Parameters.AddWithValue("@emailAddress", myAppointment.emailAddress);
                cmd.Parameters.AddWithValue("@locationAddress", myAppointment.locationAddress);
                cmd.Parameters.AddWithValue("@therapistFirstName", myAppointment.therapistFirstName);
                cmd.Parameters.AddWithValue("@therapistLastName", myAppointment.therapistLastName);
                cmd.Parameters.AddWithValue("@therapistID", myAppointment.therapistID);
                cmd.Parameters.AddWithValue("@appointmentID", myAppointment.appointmentID);
                cmd.Parameters.AddWithValue("@appointmentStartDate", myAppointment.appointmentStartDate);
                cmd.Parameters.AddWithValue("@appointmentEndDate", myAppointment.appointmentEndDate);
                cmd.Parameters.AddWithValue("@therapyType", myAppointment.therapyType);
                cmd.Parameters.AddWithValue("@isCanceled", myAppointment.isCanceled);

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