using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public static OperationResult Failed(string msg) => new OperationResult { Success = false, Message = msg };
        public static OperationResult Ok() => new OperationResult { Success = true };
    }
    public class OperationResult<T> : OperationResult
    {
        private OperationResult()
        { }

        public T Data { get; private set; }
        public static new OperationResult<T> Failed(string msg) => new OperationResult<T> { Success = false, Message = msg, };
        public static OperationResult<T> Ok(T data) => new OperationResult<T> { Success = true, Data = data };

    }
}
