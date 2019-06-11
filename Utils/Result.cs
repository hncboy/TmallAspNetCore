using System;

namespace Tmall.Core.Utils
{
    public class Result
    {
        private static int SUCCESS_CODE = 0;
        private static int FAIL_CODE = 1;

        public int Code { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public Result(int code, string message, Object data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public static Result Success()
        {
            return new Result(SUCCESS_CODE, null, null);
        }

        public static Result Success(Object data)
        {
            return new Result(SUCCESS_CODE, "", data);
        }

        public static Result Fail(String message)
        {
            return new Result(FAIL_CODE, message, null);
        }
    }
}
