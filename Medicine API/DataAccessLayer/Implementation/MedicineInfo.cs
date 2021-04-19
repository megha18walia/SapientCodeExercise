using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class MedicineInfo : IMedicineInfo
    {

        private MedicineContext _medicineContext;

        public MedicineInfo(MedicineContext _context)
        {
            _medicineContext = _context;
        }
        public async Task<bool> DeleteMedicine(Guid medicineID)
        {
            var medicine = await _medicineContext.Medicine.Where(p => p.Id == medicineID).FirstOrDefaultAsync();
            _medicineContext.Remove(medicine);
            await _medicineContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Medicine>> GetAllMedicine()
        {
            return await _medicineContext.Medicine.ToListAsync();
        }

        public async Task<Medicine> GetMedicineByID(Guid medicineID)
        {
            return await _medicineContext.Medicine.Where(p => p.Id == medicineID).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveMedicine(Medicine medicine)
        {
            var med = await _medicineContext.Medicine.Where(p => p.Id == medicine.Id).FirstOrDefaultAsync();
            if (med != null)
            {
                med.Name = medicine.Name;
                med.Price = medicine.Price;
                med.Quantity = medicine.Quantity;
                med.Brand = medicine.Brand;
                med.Notes = medicine.Notes;
                med.ExpiryDate = medicine.ExpiryDate;
                _medicineContext.Medicine.Update(med);
                await _medicineContext.SaveChangesAsync();
                return true;
            }
            else
            {
                _medicineContext.Medicine.Add(medicine);
                await _medicineContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
