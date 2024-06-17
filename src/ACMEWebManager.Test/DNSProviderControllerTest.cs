using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using ACMEWebManager.Controllers;
using ACMEWebManager.ViewModels.DNSProviderVMs;
using ACMEWebManager.Models;
using ACMEWebManager;


namespace ACMEWebManager.Test
{
    [TestClass]
    public class DNSProviderControllerTest
    {
        private DNSProviderController _controller;
        private string _seed;

        public DNSProviderControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<DNSProviderController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as DNSProviderListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(DNSProviderVM));

            DNSProviderVM vm = rv.Model as DNSProviderVM;
            DNSProvider v = new DNSProvider();
			
            v.ProviderType = ACMEWebManager.Models.ProviderType.Huawei;
            v.AppId = "7nsHpiFzTn1k9rfgon";
            v.SecretId = "VYt1vjZYgAL4jQP";
            v.SecretKey = "pt";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DNSProvider>().Find(v.ID);
				
                Assert.AreEqual(data.ProviderType, ACMEWebManager.Models.ProviderType.Huawei);
                Assert.AreEqual(data.AppId, "7nsHpiFzTn1k9rfgon");
                Assert.AreEqual(data.SecretId, "VYt1vjZYgAL4jQP");
                Assert.AreEqual(data.SecretKey, "pt");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            DNSProvider v = new DNSProvider();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ProviderType = ACMEWebManager.Models.ProviderType.Huawei;
                v.AppId = "7nsHpiFzTn1k9rfgon";
                v.SecretId = "VYt1vjZYgAL4jQP";
                v.SecretKey = "pt";
                context.Set<DNSProvider>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(DNSProviderVM));

            DNSProviderVM vm = rv.Model as DNSProviderVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new DNSProvider();
            v.ID = vm.Entity.ID;
       		
            v.ProviderType = ACMEWebManager.Models.ProviderType.Tencent;
            v.AppId = "2oAwvw7TP4IhLVgLB";
            v.SecretId = "GSujxTsDevhm3V";
            v.SecretKey = "apPhFh7S373jZuro";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ProviderType", "");
            vm.FC.Add("Entity.AppId", "");
            vm.FC.Add("Entity.SecretId", "");
            vm.FC.Add("Entity.SecretKey", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DNSProvider>().Find(v.ID);
 				
                Assert.AreEqual(data.ProviderType, ACMEWebManager.Models.ProviderType.Tencent);
                Assert.AreEqual(data.AppId, "2oAwvw7TP4IhLVgLB");
                Assert.AreEqual(data.SecretId, "GSujxTsDevhm3V");
                Assert.AreEqual(data.SecretKey, "apPhFh7S373jZuro");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            DNSProvider v = new DNSProvider();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ProviderType = ACMEWebManager.Models.ProviderType.Huawei;
                v.AppId = "7nsHpiFzTn1k9rfgon";
                v.SecretId = "VYt1vjZYgAL4jQP";
                v.SecretKey = "pt";
                context.Set<DNSProvider>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(DNSProviderVM));

            DNSProviderVM vm = rv.Model as DNSProviderVM;
            v = new DNSProvider();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DNSProvider>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            DNSProvider v = new DNSProvider();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ProviderType = ACMEWebManager.Models.ProviderType.Huawei;
                v.AppId = "7nsHpiFzTn1k9rfgon";
                v.SecretId = "VYt1vjZYgAL4jQP";
                v.SecretKey = "pt";
                context.Set<DNSProvider>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            DNSProvider v1 = new DNSProvider();
            DNSProvider v2 = new DNSProvider();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ProviderType = ACMEWebManager.Models.ProviderType.Huawei;
                v1.AppId = "7nsHpiFzTn1k9rfgon";
                v1.SecretId = "VYt1vjZYgAL4jQP";
                v1.SecretKey = "pt";
                v2.ProviderType = ACMEWebManager.Models.ProviderType.Tencent;
                v2.AppId = "2oAwvw7TP4IhLVgLB";
                v2.SecretId = "GSujxTsDevhm3V";
                v2.SecretKey = "apPhFh7S373jZuro";
                context.Set<DNSProvider>().Add(v1);
                context.Set<DNSProvider>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(DNSProviderBatchVM));

            DNSProviderBatchVM vm = rv.Model as DNSProviderBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<DNSProvider>().Find(v1.ID);
                var data2 = context.Set<DNSProvider>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            DNSProvider v1 = new DNSProvider();
            DNSProvider v2 = new DNSProvider();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ProviderType = ACMEWebManager.Models.ProviderType.Huawei;
                v1.AppId = "7nsHpiFzTn1k9rfgon";
                v1.SecretId = "VYt1vjZYgAL4jQP";
                v1.SecretKey = "pt";
                v2.ProviderType = ACMEWebManager.Models.ProviderType.Tencent;
                v2.AppId = "2oAwvw7TP4IhLVgLB";
                v2.SecretId = "GSujxTsDevhm3V";
                v2.SecretKey = "apPhFh7S373jZuro";
                context.Set<DNSProvider>().Add(v1);
                context.Set<DNSProvider>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(DNSProviderBatchVM));

            DNSProviderBatchVM vm = rv.Model as DNSProviderBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<DNSProvider>().Find(v1.ID);
                var data2 = context.Set<DNSProvider>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as DNSProviderListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
