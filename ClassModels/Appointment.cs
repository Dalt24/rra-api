namespace api_rra1.ClassModels
{
    public class Appointment
    {
        public string? userID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? emailAddress { get; set; }
        public string? locationAddress { get; set; }
        public string? therapistFirstName { get; set; }
        public string? therapistLastName { get; set; }
        public string? therapistID { get; set; }
        public string? appointmentID { get; set; }
        public string? appointmentStartDate { get; set; }
        public string? appointmentEndDate { get; set; }
        public string? therapyType { get; set; }
        public string? isCanceled { get; set; } = "false";

        public Appointment()
        {
            appointmentID = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}