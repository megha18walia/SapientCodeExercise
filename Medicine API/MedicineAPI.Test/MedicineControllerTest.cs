using AutoMapper;
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel = TaskPlannerAPI.ViewModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerAPI.Controllers;
using TaskPlannerAPI.Common;


namespace MedicineAPI.Test
{
    [TestClass]
    public class MedicineControllerTest
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
        public async Task GetAllMedicines()
        {
            // Arrange
            var medicineController = this.CreateMedicineController();
            var objectsList = new List<Medicine>();

            // Act
            objectsList.Add(new Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = Guid.NewGuid(), Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 });
            objectsList.Add(new Medicine { Brand = "Ciplex", ExpiryDate = new System.DateTime(), Id = Guid.NewGuid(), Name = "Corex", Notes = "Should be taken in Cough", Price = 150.00M, Quantity = 100 });

            this.mockMedicineInfo.Setup(x => x.GetAllMedicine()).Returns(Task.FromResult<List<Medicine>>(objectsList));
            var result = await medicineController.GetAllMedicines();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetMedicineByID()
        {
            // Arrange
            var medicineController = this.CreateMedicineController();
            var objectsList = new List<Medicine>();
            var medicineID = Guid.NewGuid();

            // Act
            var medicine =  new Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };

            this.mockMedicineInfo.Setup(x => x.GetMedicineByID(It.IsAny<Guid>())).Returns(Task.FromResult<Medicine>(medicine));
            var result = await medicineController.GetMedicineByID(medicineID);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteMedicineByID()
        {
            // Arrange
            var medicineController = this.CreateMedicineController();
            var objectsList = new List<Medicine>();
            var medicineID = Guid.NewGuid();

            // Act
            //var medicine = new Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };

            this.mockMedicineInfo.Setup(x => x.DeleteMedicine(It.IsAny<Guid>())).Returns(Task.FromResult<bool>(true));
            var result = await medicineController.DeleteMedicineByID(medicineID);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task SaveMedicine()
        {
            // Arrange
            var medicineController = this.CreateMedicineController();
            var objectsList = new List<Medicine>();
            var medicineID = Guid.NewGuid();

            // Act
            var medicine = new  Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Id = medicineID, Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };
            var v_medicine = new ViewModel.Medicine { Brand = "Cipla", ExpiryDate = new System.DateTime(), Name = "Dolo", Notes = "Should be taken in Fever", Price = 100.00M, Quantity = 100 };

            this.mapper.Setup(m => m.Map<ViewModel.Medicine, Medicine>(It.IsAny<ViewModel.Medicine>())).Returns(medicine);
            //this.mapper.Setup(m => m.Map<ViewModel.Medicine, Medicine>(It.IsAny<ViewModel.Medicine>())).Returns(medicine);
            this.mockMedicineInfo.Setup(x => x.SaveMedicine(It.IsAny<Medicine>())).Returns(Task.FromResult<bool>(true));
            var result = await medicineController.SaveProject(v_medicine);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        private MedicineController CreateMedicineController()
        {
            return new MedicineController(this.mockMedicineInfo.Object, this.mapper.Object);
                
        }
    }
}
