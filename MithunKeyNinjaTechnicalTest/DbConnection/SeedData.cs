using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MithunKeyNinjaTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MithunKeyNinjaTechnicalTest.DbConnection
{
    public static class SeedData
    {
        public async static void Initialize(IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = new Context())
                {
                    context.Database.EnsureCreated();
                    {
                        if (context.Rider.Count() == 0)
                        {
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                IList<Rider> rider = new List<Rider>();

                                rider.Add(new Rider() { Id = 1, FirstName = "Mithun", LastName = "Poddar", PhoneNumber = "0452038779", Email = "ce.mithun@gmail.com", StartDate = DateTime.Now });
                                rider.Add(new Rider() { Id = 2, FirstName = "Bijay", LastName = "Poddar", PhoneNumber = "0452038774", Email = "bijay@gmail.com", StartDate = DateTime.Now });
                                rider.Add(new Rider() { Id = 3, FirstName = "Smriti", LastName = "Shakya", PhoneNumber = "0452038775", Email = "shakya@gmail.com", StartDate = DateTime.Now });
                                rider.Add(new Rider() { Id = 4, FirstName = "Albert", LastName = "Amatya", PhoneNumber = "0452038773", Email = "albert@gmail.com", StartDate = DateTime.Now });
                                rider.Add(new Rider() { Id = 5, FirstName = "John", LastName = "Smith", PhoneNumber = "0452038772", Email = "john@gmail.com", StartDate = DateTime.Now });
                                rider.Add(new Rider() { Id = 6, FirstName = "Naren", LastName = "Maharjan", PhoneNumber = "0452038771", Email = "naren@gmail.com", StartDate = DateTime.Now });

                                context.Rider.AddRange(rider);
                                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Rider ON");
                                await context.SaveChangesAsync();
                                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Rider OFF");
                                transaction.Commit();
                            }
                        }
                        if (context.Jobs.Count() == 0)
                        {
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                IList<Jobs> jobs = new List<Jobs>();
                                jobs.Add(new Jobs() { Id = 1, DateTime = DateTime.Now.AddHours(-2), RiderId = 1, ReviewScore = 1, ReviewComment = "average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 2, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 2, ReviewComment = "above average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 3, DateTime = DateTime.Now.AddHours(-2), RiderId = 3, ReviewScore = 2, ReviewComment = "above average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 4, DateTime = DateTime.Now.AddHours(-2), RiderId = 4, ReviewScore = 3, ReviewComment = "nice perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 5, DateTime = DateTime.Now.AddHours(-2), RiderId = 5, ReviewScore = 5, ReviewComment = "good perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 6, DateTime = DateTime.Now.AddHours(-2), RiderId = 6, ReviewScore = 8, ReviewComment = "excellent perpormance", CompletedAt = DateTime.Now });

                                jobs.Add(new Jobs() { Id = 7, DateTime = DateTime.Now.AddHours(-2), RiderId = 1, ReviewScore = 7, ReviewComment = "excellent perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 8, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 4, ReviewComment = "nice perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 9, DateTime = DateTime.Now.AddHours(-2), RiderId = 3, ReviewScore = 6, ReviewComment = "good perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 10, DateTime = DateTime.Now.AddHours(-2), RiderId =4, ReviewScore = 5, ReviewComment = "good average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 11, DateTime = DateTime.Now.AddHours(-2), RiderId = 5, ReviewScore = 2, ReviewComment = "above average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 12, DateTime = DateTime.Now.AddHours(-2), RiderId = 6, ReviewScore = 1, ReviewComment = "average perpormance", CompletedAt = DateTime.Now });

                                jobs.Add(new Jobs() { Id = 13, DateTime = DateTime.Now.AddHours(-2), RiderId = 1, ReviewScore = 6, ReviewComment = "good perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 14, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 7, ReviewComment = "excellent average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 15, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 4, ReviewComment = "nice average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 16, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 3, ReviewComment = "nice average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 17, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 2, ReviewComment = "above average perpormance", CompletedAt = DateTime.Now });
                                jobs.Add(new Jobs() { Id = 18, DateTime = DateTime.Now.AddHours(-2), RiderId = 2, ReviewScore = 1, ReviewComment = "average perpormance", CompletedAt = DateTime.Now });

                                context.Jobs.AddRange(jobs);
                                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Jobs ON");
                                await context.SaveChangesAsync();
                                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Jobs OFF");
                                transaction.Commit();
                            }
                        }
                    }
                }
            }
        }
    }
}