using System.Linq;

namespace ComputerEquipment.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ComputerEquipmentContext context)
        {
            context.Database.EnsureCreated();
            if (context.DeviceTypes.Any())
            {
                return;
            }
            var deviceTypes = new DeviceType[]
            {
                new DeviceType(){Name = "laptop"},
                new DeviceType(){Name = "mouse"},
                new DeviceType(){Name = "keyboard"},
                new DeviceType(){Name = "computer"},
                new DeviceType(){Name = "monitor"}
            };
            context.DeviceTypes.AddRange(deviceTypes);
            var producers = new Producer[]
            {
                new Producer(){Name = "lenovo"},
                new Producer(){Name = "acer"},
                new Producer(){Name = "asus"}
            };
            context.Producers.AddRange(producers);
            context.SaveChanges();
        }
    }
}
