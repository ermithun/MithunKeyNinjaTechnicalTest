using MithunKeyNinjaTechnicalTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MithunKeyNinjaTechnicalTest.DbConnection
{
    public class RiderDAL
    {
        private Context context;

        public RiderDAL()
        {
            context = new Context();
        }

        public IQueryable<T> GetModelList<T>() where T : class
        {
            return context.Set<T>();
        }


        public  AppResult Create<T>(T model) where T : class
        {
            AppResult result = null;
            using (var context = new Context())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Set<T>().Add(model);
                        context.SaveChanges();
                        result = new AppResult { ResultType = ResultType.Success, Message = "Message -! Successfully Inserted." };
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        result = new AppResult { ResultType = ResultType.Exception, Message = ex.Message.ToString() };
                    }
                }
            }
            return result;
        }

        public  AppResult Update<T>(T model) where T : class
        {
            AppResult result = null;
            using (var context = new Context())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Set<T>().Update(model);
                        context.SaveChanges();
                        result = new AppResult { ResultType = ResultType.Success, Message = "Message -! Successfully Updated." };
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        result = new AppResult { ResultType = ResultType.Exception, Message = ex.Message.ToString() };
                    }
                }
            }
            return result;
        }

        public  AppResult Delete<T>(T model) where T : class
        {
            AppResult result = null;
            using (var context = new Context())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Set<T>().Remove(model);
                        context.SaveChanges();
                        result = new AppResult { ResultType = ResultType.Success, Message = "Message -! Successfully Deleted." };
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        result = new AppResult { ResultType = ResultType.Exception, Message = ex.Message.ToString() };
                    }
                }
            }
            return result;
        }
    }
}
