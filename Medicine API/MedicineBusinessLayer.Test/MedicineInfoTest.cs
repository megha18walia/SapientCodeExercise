using AutoMapper;
using DataAccessLayer.Implementation;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using BusinessModel = BusinessLayer.Models;
using DataModel = DataAccessLayer.Models;
using BusinessInterface = BusinessLayer.Interfaces;
using BusinessImplementation = BusinessLayer.Implementation;
using DataInterface = DataAccessLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineBusinessLayer.Test
{
    [TestClass]
    public class MedicineBusinessLayerTest
    {
        private MockRepository mockRepository;
        /// <summary>
        /// data access feedback repository
        /// </summary>
        private Mock<IMedicineInfo> mockMedicineInfo;

        private IMedicineInfo medicineInfo;

        /// <summary>
        /// auto mapper
        /// </summary>
        private Mock<IMapper> mapper;

        /// <summary>
        /// Test Initialize
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // this.medicineInfo = new MedicineInfo()
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockMedicineInfo = this.mockRepository.Create<IMedicineInfo>();
            //var myProfile = new AutoMapperProfile();
            //var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            this.mapper = this.mockRepository.Create<IMapper>();
        }

        [TestMethod]
        public async Task DeleteMedicine()
        {
            // Arrange
            var medicineBusinessLayer = this.CreateMedicineBusinessLayer();
            var objectsList = new List<BusinessModel.Medicine>();
            var medicineID = Guid.NewGuid();

            // Act
            //var medicine = new Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };

            this.mockMedicineInfo.Setup(x => x.DeleteMedicine(It.IsAny<Guid>())).Returns(Task.FromResult<bool>(true));
            var result = await medicineBusinessLayer.DeleteMedicine(medicineID);

            // Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public async Task GetAllMedicine()
        {
            // Arrange
            var medicineBusinessLayer = this.CreateMedicineBusinessLayer();
            var objectsList = new List<DataModel.Medicine>();
            var objectsListBusiness = new List<BusinessModel.Medicine>();
            var medicineID = Guid.NewGuid();

            // Act
            objectsList.Add( new DataModel.Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 });
            BusinessModel.Medicine med = new BusinessModel.Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };
            objectsListBusiness.Add(med);

            this.mockMedicineInfo.Setup(x => x.GetAllMedicine()).Returns(Task.FromResult<List<DataModel.Medicine>>(objectsList));
            this.mapper.Setup(m => m.Map<DataModel.Medicine, BusinessModel.Medicine>(It.IsAny<DataModel.Medicine>())).Returns(med);
            var result = await medicineBusinessLayer.GetAllMedicine();

            // Assert
            Assert.AreEqual(result.Count, objectsList.Count);
        }

        [TestMethod]
        public async Task GetMedicineByID()
        {
            // Arrange
            var medicineBusinessLayer = this.CreateMedicineBusinessLayer();
           // var objectsList = new List<DataModel.Medicine>();
           // var objectsListBusiness = new List<BusinessModel.Medicine>();
            var medicineID = Guid.NewGuid();

            // Act
            DataModel.Medicine medi = new DataModel.Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };
            BusinessModel.Medicine med = new BusinessModel.Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };
            BusinessModel.Medicine medical = null;
            //objectsListBusiness.Add(med);

            this.mockMedicineInfo.Setup(x => x.GetMedicineByID(It.IsAny<Guid>())).Returns(Task.FromResult<DataModel.Medicine>(medi));
            this.mapper.Setup(m => m.Map<DataModel.Medicine, BusinessModel.Medicine>(It.IsAny<DataModel.Medicine>())).Returns(med);
            var result = await medicineBusinessLayer.GetMedicineByID(medicineID);

            // Assert
            Assert.AreEqual(result, medical);
        }

        public BusinessImplementation.MedicineInfo CreateMedicineBusinessLayer()
        {
            return new BusinessImplementation.MedicineInfo(this.mockMedicineInfo.Object, this.mapper.Object);
        }
    }
}
