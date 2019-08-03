﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MithunKeyNinjaTechnicalTest.Helper
{
    public class AppResult
    {
        public ResultType ResultType { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }


    }
    public enum ResultType
    {
        Failed = 0,
        Success = 1,
        Exception = 2
    }

}
