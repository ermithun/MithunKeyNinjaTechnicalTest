using MithunKeyNinjaTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MithunKeyNinjaTechnicalTest.ViewModels
{
    public class RiderReview:Rider 
    {
        public double AverageReviewScore { get; set; }
        public int BestReviewScore { get; set; } 
        public string BestReviewComments { get; set; }
    }
}
