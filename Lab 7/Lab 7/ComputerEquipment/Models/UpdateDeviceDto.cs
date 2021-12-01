using System.ComponentModel.DataAnnotations;

namespace ComputerEquipment.Models
{
    public class UpdateDeviceDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Maker { get; set; }
    }
}
