using AutoMapper;
using ComputerEquipment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipment.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : Controller
    {
        private readonly ComputerEquipmentContext _context;
        private readonly IMapper _mapper;

        public ProducerController(ComputerEquipmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<ProducerVm>> GetAll()
        {
            var producers = _context.Producers
                .AsEnumerable();
            return Ok(_mapper.Map<IEnumerable<ProducerVm>>(producers));
        }
    }
}
