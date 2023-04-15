namespace api_rra1.ClassModels
{
    public class Therapist
    {
        public string? therapistID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? availability { get; set; }
        public string? emailAddress { get; set; }
        public string? therapistPassword { get; set; }
        public string? isAdmin { get; set; }
        public string? isTherapist { get; set; } = "true";
        public Therapist()
        {
            therapistID = Guid.NewGuid().ToString();
        }
    }
}