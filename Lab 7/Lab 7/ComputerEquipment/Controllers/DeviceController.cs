using AutoMapper;
using ComputerEquipment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipment.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        private readonly ComputerEquipmentContext _context;
        private readonly IMapper _mapper;

        public DeviceController(ComputerEquipmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<DeviceVm>> GetAll()
        {
            var devices = _context.Devices
                .Include(d=>d.DeviceType)
                .Include(d=>d.Producer)
                .AsEnumerable();
            var devicesVm = _mapper.Map<IEnumerable<DeviceVm>>(devices);
            return Ok(devicesVm);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDeviceDto createDeviceDto)
        {
            var device = _mapper.Map<Device>(createDeviceDto);
            if(createDeviceDto.Type!=null && createDeviceDto.Maker != null)
            {
                var producer = await _context.Producers.FirstOrDefaultAsync(p => p.Name.ToLower() == createDeviceDto.Maker.ToLower());
                var deviceType = await _context.DeviceTypes.FirstOrDefaultAsync(p => p.Name.ToLower() == createDeviceDto.Type.ToLower());
                if (producer != null && deviceType != null)
                {
                    device.ProducerId = producer.Id;
                    device.DeviceTypeId = deviceType.Id;
                }
                else return BadRequest("Maker or Type don't exist");
            }
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
            return Ok(device.Id);
        }
        [HttpGet]
        [Route("GetDevicesByType")]
        public ActionResult<IEnumerable<DeviceVm>> GetDevicesByType(string search)
        {
            var devices = _context.Devices
                .Where(d => d.DeviceType.Name.Contains(search.ToLower()))
                .Include(d => d.DeviceType)
                .Include(d => d.Producer)
                .AsEnumerable();
            var devicesVm = _mapper.Map<IEnumerable<DeviceVm>>(devices);
            return Ok(devicesVm);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateDevice([FromBody] UpdateDeviceDto updateDeviceDto)
        {
            var device = await _context.Devices.FindAsync(updateDeviceDto.Id);
            if (device == null)
                return BadRequest("Such a device doesn't exist");
            if (updateDeviceDto.Type != null && updateDeviceDto.Maker != null)
            {
                var producer = await _context.Producers.FirstOrDefaultAsync(p => p.Name.ToLower() == updateDeviceDto.Maker.ToLower());
                var deviceType = await _context.DeviceTypes.FirstOrDefaultAsync(p => p.Name.ToLower() == updateDeviceDto.Type.ToLower());
                if (producer != null && deviceType != null)
                {
                    device.ProducerId = producer.Id;
                    device.DeviceTypeId = deviceType.Id;
                }
                else return BadRequest("Maker or Type don't exist");
                device.Name = updateDeviceDto.Name;
                device.Price = updateDeviceDto.Price;
                device.Description = updateDeviceDto.Description;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
                _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
