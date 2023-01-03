namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerID { get; set; }
        public string ReferenceNumber { get; set; }
        public string EmailId { get; set; }
        public string DOB { get; set; }
    }
}