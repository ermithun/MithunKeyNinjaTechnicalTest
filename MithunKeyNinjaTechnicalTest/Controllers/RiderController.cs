using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MithunKeyNinjaTechnicalTest.Models;
using MithunKeyNinjaTechnicalTest.DbConnection;
using MithunKeyNinjaTechnicalTest.Helper;

namespace MithunKeyNinjaTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    public class RiderController : Controller
    {
        private RiderDAL dll = new RiderDAL();

        // GET: 
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Rider> List()
        { 
            return dll.GetModelList<Rider>().ToList();
        }

        // GET: 
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Rider> AverageRiderReview() 
        {
            //var model= from c in dll.GetModelList<Rider>()
            //           join d in dll.GetModelList<Jobs>() on c.Id.Equals(d.RiderId)
            //           select new 



            return dll.GetModelList<Rider>().ToList();
        }

        // GET 
        [HttpGet]
        [Route("[action]")]
        public Rider  Edit(int Id)
        {
            return dll.GetModelList<Rider>().Where(a=>a.Id==Id).FirstOrDefault(); 
        }

        // Create Rider
        [HttpPost]
        [Route("[action]")]
        public ActionResult Create(Rider model)
        {
            AppResult result = new AppResult();
            try
            {
                result = dll.Create<Rider>(model);
                if (result.ResultType == ResultType.Success || result.ResultType == ResultType.Failed)
                {
                    return Json(result);
                }
                else
                {
                    result = new AppResult { ResultType = ResultType.Failed, Message = "Something wrong with the system. please contact to vendor." };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                result = new AppResult { ResultType = ResultType.Failed, Message = ex.Message.ToString() };
                return Json(result);
            }
        }

        // PUT 
        [HttpPut]
        [Route("[action]")]
        public ActionResult Update(Rider model)
        {
            AppResult result = new AppResult();
            try
            {
                    result =  dll.Update<Rider>(model);
                    if (result.ResultType == ResultType.Success || result.ResultType == ResultType.Failed)
                    {
                        return Json(result);
                    }
                    else
                    {
                        result = new AppResult { ResultType = ResultType.Failed, Message = "Something wrong with the system. please contact to vendor." };
                        return Json(result);
                    }
               
            }
            catch (Exception ex)
            {
                result = new AppResult { ResultType = ResultType.Failed, Message = ex.Message.ToString() };
                return Json(result);
            }
        }

        // DELETE 
        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete(int id)
        {
            AppResult result = new AppResult();
            try
            {
                Rider model = dll.GetModelList<Rider>().Where(a => a.Id == id).FirstOrDefault();
                result =dll.Delete<Rider>(model);
                if (result.ResultType == ResultType.Success || result.ResultType == ResultType.Failed)
                {
                    return Json(result);
                }
                else
                {
                    result = new AppResult { ResultType = ResultType.Failed, Message = "Something wrong with the system. please contact to vendor." };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                result = new AppResult { ResultType = ResultType.Failed, Message = ex.Message.ToString() };
                return Json(result);
            }
        }
    }
}
