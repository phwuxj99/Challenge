namespace Challenge.Models
{
    public class InsurancePolicy
    {
        public string PrincipalRegulator { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DriversLicense { get; set; }
        public Vehicledetails Vehicledetails { get; set; }
        public string Address { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Premium { get; set; }
    }

    public class Vehicledetails
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleName { get; set; }
    }
}
