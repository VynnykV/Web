namespace ComputerEquipment.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int? DeviceTypeId { get; set; }
        public int? ProducerId { get; set; }

        public DeviceType DeviceType { get; set; }
        public Producer Producer { get; set; }
    }
}
