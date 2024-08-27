namespace CargoLoadAPI.Server.Models
{
    public class CargoLoad
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public double LoadWeight { get; set; }
        public bool IsDangerousGoods { get; set; }
    }
}

