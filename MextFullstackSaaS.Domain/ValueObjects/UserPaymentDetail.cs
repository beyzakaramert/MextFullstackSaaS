namespace MextFullstackSaaS.Domain.ValueObjects
{
    public class UserPaymentDetail
    {
        //Buyer buyer = new Buyer
        //{
        //    Id = "BY789",
        //    Name = "Alper",
        //    Surname = "Tunga",
        //    GsmNumber = "+905350000000",
        //    Email = "email@email.com",
        //    IdentityNumber = "74300864791",
        //    LastLoginDate = "2015-10-05 12:43:35",
        //    RegistrationDate = "2013-04-21 15:12:09",
        //    RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
        //    Ip = "85.34.78.112",
        //    City = "Istanbul",
        //    Country = "Turkey",
        //    ZipCode = "34732"
        //};
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Ip { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
