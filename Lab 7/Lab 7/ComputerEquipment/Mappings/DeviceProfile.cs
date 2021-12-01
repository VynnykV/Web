using AutoMapper;
using ComputerEquipment.Models;


namespace ComputerEquipment.Mappings
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceVm>()
                .ForMember(vm => vm.Name,
                opt => opt.MapFrom(d => d.Name))
                .ForMember(vm => vm.Price,
                opt => opt.MapFrom(d => d.Price))
                .ForMember(vm => vm.Description,
                opt => opt.MapFrom(d => d.Description))
                .ForMember(vm => vm.DeviceType,
                opt => opt.MapFrom(d => d.DeviceType.Name))
                .ForMember(vm => vm.Producer,
                opt => opt.MapFrom(d => d.Producer.Name));
            CreateMap<CreateDeviceDto, Device>()
                .ForMember(d => d.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(d => d.Price,
                opt => opt.MapFrom(dto => dto.Price))
                .ForMember(d => d.Description,
                opt => opt.MapFrom(dto => dto.Description));
            CreateMap<UpdateDeviceDto, Device>()
                .ForMember(d => d.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(d => d.Price,
                opt => opt.MapFrom(dto => dto.Price))
                .ForMember(d => d.Description,
                opt => opt.MapFrom(dto => dto.Description));
        }
    }
}
