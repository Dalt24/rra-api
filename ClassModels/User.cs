namespace api_rra1.ClassModels.Database
{
    //   firstName: firstName,
    //       lastName: lastName,
    //       emailAddress: userEmail,
    //       phoneNumber: phoneNumber,
    //       userPassword: passWordOne,
    public class User
    {
        public string? userID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? emailAddress { get; set; }
        public string? phoneNumber { get; set; }
        public string? userPassword { get; set; }
        public string? isAdmin { get; set; }
        public string? isTherapist { get; set; }

        public User()
        {
            userID = Guid.NewGuid().ToString();
        }

    }
}