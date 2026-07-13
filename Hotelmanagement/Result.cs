using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Result
    {
        public bool Succes { get;  private set; }
        public string Message { get; private  set; }
        public static Result Failed(string msg)
        {
            Result result = new Result();
            result.Message = msg;
            result.Succes = false;
            return result;
        }
        public static Result Ok()
        {
            Result result = new Result();
            result.Succes=true;
            return result;
        }
    }
}
