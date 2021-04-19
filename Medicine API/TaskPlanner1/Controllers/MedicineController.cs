using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace TaskPlannerAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private IMedicineInfo _medicineInfo;
        private IMapper mapper;
        public MedicineController(IMedicineInfo medicineInfo, IMapper map)
        {
            _medicineInfo = medicineInfo;
            mapper = map;
            
        }

        [HttpGet]
        [Route("GetMedicines")]
        public async Task<IActionResult> GetAllMedicines()
        {
            var result = await _medicineInfo.GetAllMedicine();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMedicinesByID/{medicineId}")]
        public async Task<IActionResult> GetMedicineByID(Guid medicineId)
        {
            var result = await _medicineInfo.GetMedicineByID(medicineId);
            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteMedicineByID/{medicineId}")]
        public async Task<IActionResult> DeleteMedicineByID(Guid medicineId)
        {
            var result = await _medicineInfo.DeleteMedicine(medicineId);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveMedicine")]
        public async Task<IActionResult> SaveProject([FromBody] ViewModel.Medicine medicine)
        {
            var med = mapper.Map<BusinessLayer.Models.Medicine>(medicine);
            var result = await _medicineInfo.SaveMedicine(med);
            return Ok(result);
        }

       
    }
}