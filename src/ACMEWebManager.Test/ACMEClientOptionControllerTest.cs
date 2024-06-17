using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using ACMEWebManager.Controllers;
using ACMEWebManager.ViewModels.ACMEClientOptionVMs;
using ACMEWebManager.Models;
using ACMEWebManager;


namespace ACMEWebManager.Test
{
    [TestClass]
    public class ACMEClientOptionControllerTest
    {
        private ACMEClientOptionController _controller;
        private string _seed;

        public ACMEClientOptionControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ACMEClientOptionController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as ACMEClientOptionListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ACMEClientOptionVM));

            ACMEClientOptionVM vm = rv.Model as ACMEClientOptionVM;
            ACMEClientOption v = new ACMEClientOption();
			
            v.Mail = "MKm6jB1ui";
            v.CA = ACMEWebManager.Models.CA.LetsEncrypt;
            v.Domain = "RSoKK6wv4mXlGD";
            v.CountryName = "UWDJ6r5jnaLNqR";
            v.State = "8IYTL1j4K32v3NtcI";
            v.Locality = "gsPh";
            v.Organization = "kLZ90vsEOO";
            v.OrganizationUnit = "FstUKEVnnH";
            v.CommonName = "AbjEI25X9fh99wbx";
            v.DNSProviderId = AddDNSProvider();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ACMEClientOption>().Find(v.ID);
				
                Assert.AreEqual(data.Mail, "MKm6jB1ui");
                Assert.AreEqual(data.CA, ACMEWebManager.Models.CA.LetsEncrypt);
                Assert.AreEqual(data.Domain, "RSoKK6wv4mXlGD");
                Assert.AreEqual(data.CountryName, "UWDJ6r5jnaLNqR");
                Assert.AreEqual(data.State, "8IYTL1j4K32v3NtcI");
                Assert.AreEqual(data.Locality, "gsPh");
                Assert.AreEqual(data.Organization, "kLZ90vsEOO");
                Assert.AreEqual(data.OrganizationUnit, "FstUKEVnnH");
                Assert.AreEqual(data.CommonName, "AbjEI25X9fh99wbx");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ACMEClientOption v = new ACMEClientOption();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Mail = "MKm6jB1ui";
                v.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v.Domain = "RSoKK6wv4mXlGD";
                v.CountryName = "UWDJ6r5jnaLNqR";
                v.State = "8IYTL1j4K32v3NtcI";
                v.Locality = "gsPh";
                v.Organization = "kLZ90vsEOO";
                v.OrganizationUnit = "FstUKEVnnH";
                v.CommonName = "AbjEI25X9fh99wbx";
                v.DNSProviderId = AddDNSProvider();
                context.Set<ACMEClientOption>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ACMEClientOptionVM));

            ACMEClientOptionVM vm = rv.Model as ACMEClientOptionVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new ACMEClientOption();
            v.ID = vm.Entity.ID;
       		
            v.Mail = "faIbGK655NW1UDJqlq";
            v.CA = ACMEWebManager.Models.CA.LetsEncrypt;
            v.Domain = "93J";
            v.CountryName = "xnG7klR8erNr5lTOfz";
            v.State = "ZtlqkH8DyFu";
            v.Locality = "yA5wKGGS7lDMAnW";
            v.Organization = "pDh9g1A0";
            v.OrganizationUnit = "Lv";
            v.CommonName = "2d8uuIbnn";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Mail", "");
            vm.FC.Add("Entity.CA", "");
            vm.FC.Add("Entity.Domain", "");
            vm.FC.Add("Entity.CountryName", "");
            vm.FC.Add("Entity.State", "");
            vm.FC.Add("Entity.Locality", "");
            vm.FC.Add("Entity.Organization", "");
            vm.FC.Add("Entity.OrganizationUnit", "");
            vm.FC.Add("Entity.CommonName", "");
            vm.FC.Add("Entity.DNSProviderId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ACMEClientOption>().Find(v.ID);
 				
                Assert.AreEqual(data.Mail, "faIbGK655NW1UDJqlq");
                Assert.AreEqual(data.CA, ACMEWebManager.Models.CA.LetsEncrypt);
                Assert.AreEqual(data.Domain, "93J");
                Assert.AreEqual(data.CountryName, "xnG7klR8erNr5lTOfz");
                Assert.AreEqual(data.State, "ZtlqkH8DyFu");
                Assert.AreEqual(data.Locality, "yA5wKGGS7lDMAnW");
                Assert.AreEqual(data.Organization, "pDh9g1A0");
                Assert.AreEqual(data.OrganizationUnit, "Lv");
                Assert.AreEqual(data.CommonName, "2d8uuIbnn");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ACMEClientOption v = new ACMEClientOption();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Mail = "MKm6jB1ui";
                v.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v.Domain = "RSoKK6wv4mXlGD";
                v.CountryName = "UWDJ6r5jnaLNqR";
                v.State = "8IYTL1j4K32v3NtcI";
                v.Locality = "gsPh";
                v.Organization = "kLZ90vsEOO";
                v.OrganizationUnit = "FstUKEVnnH";
                v.CommonName = "AbjEI25X9fh99wbx";
                v.DNSProviderId = AddDNSProvider();
                context.Set<ACMEClientOption>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ACMEClientOptionVM));

            ACMEClientOptionVM vm = rv.Model as ACMEClientOptionVM;
            v = new ACMEClientOption();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ACMEClientOption>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ACMEClientOption v = new ACMEClientOption();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Mail = "MKm6jB1ui";
                v.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v.Domain = "RSoKK6wv4mXlGD";
                v.CountryName = "UWDJ6r5jnaLNqR";
                v.State = "8IYTL1j4K32v3NtcI";
                v.Locality = "gsPh";
                v.Organization = "kLZ90vsEOO";
                v.OrganizationUnit = "FstUKEVnnH";
                v.CommonName = "AbjEI25X9fh99wbx";
                v.DNSProviderId = AddDNSProvider();
                context.Set<ACMEClientOption>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            ACMEClientOption v1 = new ACMEClientOption();
            ACMEClientOption v2 = new ACMEClientOption();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Mail = "MKm6jB1ui";
                v1.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v1.Domain = "RSoKK6wv4mXlGD";
                v1.CountryName = "UWDJ6r5jnaLNqR";
                v1.State = "8IYTL1j4K32v3NtcI";
                v1.Locality = "gsPh";
                v1.Organization = "kLZ90vsEOO";
                v1.OrganizationUnit = "FstUKEVnnH";
                v1.CommonName = "AbjEI25X9fh99wbx";
                v1.DNSProviderId = AddDNSProvider();
                v2.Mail = "faIbGK655NW1UDJqlq";
                v2.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v2.Domain = "93J";
                v2.CountryName = "xnG7klR8erNr5lTOfz";
                v2.State = "ZtlqkH8DyFu";
                v2.Locality = "yA5wKGGS7lDMAnW";
                v2.Organization = "pDh9g1A0";
                v2.OrganizationUnit = "Lv";
                v2.CommonName = "2d8uuIbnn";
                v2.DNSProviderId = v1.DNSProviderId; 
                context.Set<ACMEClientOption>().Add(v1);
                context.Set<ACMEClientOption>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ACMEClientOptionBatchVM));

            ACMEClientOptionBatchVM vm = rv.Model as ACMEClientOptionBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ACMEClientOption>().Find(v1.ID);
                var data2 = context.Set<ACMEClientOption>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            ACMEClientOption v1 = new ACMEClientOption();
            ACMEClientOption v2 = new ACMEClientOption();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Mail = "MKm6jB1ui";
                v1.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v1.Domain = "RSoKK6wv4mXlGD";
                v1.CountryName = "UWDJ6r5jnaLNqR";
                v1.State = "8IYTL1j4K32v3NtcI";
                v1.Locality = "gsPh";
                v1.Organization = "kLZ90vsEOO";
                v1.OrganizationUnit = "FstUKEVnnH";
                v1.CommonName = "AbjEI25X9fh99wbx";
                v1.DNSProviderId = AddDNSProvider();
                v2.Mail = "faIbGK655NW1UDJqlq";
                v2.CA = ACMEWebManager.Models.CA.LetsEncrypt;
                v2.Domain = "93J";
                v2.CountryName = "xnG7klR8erNr5lTOfz";
                v2.State = "ZtlqkH8DyFu";
                v2.Locality = "yA5wKGGS7lDMAnW";
                v2.Organization = "pDh9g1A0";
                v2.OrganizationUnit = "Lv";
                v2.CommonName = "2d8uuIbnn";
                v2.DNSProviderId = v1.DNSProviderId; 
                context.Set<ACMEClientOption>().Add(v1);
                context.Set<ACMEClientOption>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ACMEClientOptionBatchVM));

            ACMEClientOptionBatchVM vm = rv.Model as ACMEClientOptionBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ACMEClientOption>().Find(v1.ID);
                var data2 = context.Set<ACMEClientOption>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as ACMEClientOptionListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddDNSProvider()
        {
            DNSProvider v = new DNSProvider();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.ProviderType = ACMEWebManager.Models.ProviderType.Aliyun;
                v.AppId = "YopC8v2AKjLd2wRji0C";
                v.SecretId = "Oe2aUL";
                v.SecretKey = "I9RwjYgZyhscqn";
                context.Set<DNSProvider>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
