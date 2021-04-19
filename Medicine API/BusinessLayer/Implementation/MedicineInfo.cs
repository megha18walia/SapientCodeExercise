using AutoMapper;
using BusinessModel = BusinessLayer.Models;
using DataModel = DataAccessLayer.Models;
using BusinessInterface = BusinessLayer.Interfaces;
using DataInterface = DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementation
{
    public class MedicineInfo : BusinessInterface.IMedicineInfo
    {
        private DataInterface.IMedicineInfo _medicineInfo;
        private IMapper mapper;
        public MedicineInfo(DataInterface.IMedicineInfo _medicine, IMapper _mapper)
        {
            _medicineInfo = _medicine;
            mapper = _mapper;
        }
        public async Task<bool> DeleteMedicine(Guid medicineID)
        {
            return await _medicineInfo.DeleteMedicine(medicineID);
        }

        public async Task<List<BusinessModel.Medicine>> GetAllMedicine()
        {
            List<DataModel.Medicine> medicines = await _medicineInfo.GetAllMedicine();
            List<BusinessModel.Medicine> projData = new List<BusinessModel.Medicine>();
            foreach (var project in medicines)
            {
                projData.Add(mapper.Map<BusinessModel.Medicine>(project));
            }
            return projData;
        }

        public async Task<BusinessModel.Medicine> GetMedicineByID(Guid medicineID)
        {
            DataModel.Medicine medicine = await _medicineInfo.GetMedicineByID(medicineID);
            return mapper.Map<BusinessModel.Medicine>(medicine);
        }

        public async Task<bool> SaveMedicine(BusinessModel.Medicine medicine)
        {
            if (medicine.Id == null || medicine.Id == Guid.Empty)
                medicine.Id = Guid.NewGuid();

            DataModel.Medicine med = mapper.Map<DataModel.Medicine>(medicine);
            return await _medicineInfo.SaveMedicine(med);
        }
    }
}
