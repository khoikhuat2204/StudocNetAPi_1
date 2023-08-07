using System.Text.Json.Serialization;

namespace StudocNetAPi_1.Models.ResponseModels
{
    public class OwnerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
    }
}
