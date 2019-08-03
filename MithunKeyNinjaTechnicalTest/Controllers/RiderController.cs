using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MithunKeyNinjaTechnicalTest.Models;
using MithunKeyNinjaTechnicalTest.DbConnection;
using MithunKeyNinjaTechnicalTest.Helper;
using MithunKeyNinjaTechnicalTest.ViewModels;

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
        public IEnumerable<RiderReview> RiderReview()
        {
            var riderScores =
                from rider in dll.GetModelList<Jobs>()
                group rider by rider.Rider into riderGroup
                select new
                {
                    RiderId = riderGroup.FirstOrDefault().RiderId,
                    AverageScore = riderGroup.Average(x => x.ReviewScore),
                    BestReviewScore = riderGroup.Max(x => x.ReviewScore),
                    BestReviewComment = riderGroup.Where(x => x.ReviewScore == riderGroup.Max(xy => xy.ReviewScore)).FirstOrDefault().ReviewComment
                };
            var query = from rider in dll.GetModelList<Rider>()
                        join score in riderScores
                             on rider.Id equals score.RiderId
                        select new RiderReview
                        {
                            FirstName = rider.FirstName,
                            LastName = rider.LastName,
                            PhoneNumber = rider.PhoneNumber,
                            Email = rider.Email,
                            StartDate = rider.StartDate,
                            AverageReviewScore = score.AverageScore,
                            BestReviewScore = score.BestReviewScore,
                            BestReviewComments = score.BestReviewComment
                        };

            return query;
        }

        // GET 
        [HttpGet]
        [Route("[action]")]
        public Rider Edit(int Id)
        {
            return dll.GetModelList<Rider>().Where(a => a.Id == Id).FirstOrDefault();
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
                result = dll.Update<Rider>(model);
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
                result = dll.Delete<Rider>(model);
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
