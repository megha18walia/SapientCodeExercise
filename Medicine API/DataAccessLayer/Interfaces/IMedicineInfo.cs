﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMedicineInfo
    {
        Task<List<Medicine>> GetAllMedicine();

        Task<Medicine> GetMedicineByID(Guid medicineID);

        Task<bool> SaveMedicine(Medicine medicine);

        Task<bool> DeleteMedicine(Guid medicineID);
    }
}
