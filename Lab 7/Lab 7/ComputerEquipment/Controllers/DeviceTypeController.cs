using AutoMapper;
using ComputerEquipment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ComputerEquipment.Controllers
{
    [Route("api/[controller]")]
    public class DeviceTypeController : Controller
    {
        private readonly ComputerEquipmentContext _context;
        private readonly IMapper _mapper;

        public DeviceTypeController(ComputerEquipmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<DeviceTypeVm>> GetAll()
        {
            var deviceTypes = _context.DeviceTypes
                .AsEnumerable();
            return Ok(_mapper.Map<IEnumerable<DeviceTypeVm>>(deviceTypes));
        }
    }
}
