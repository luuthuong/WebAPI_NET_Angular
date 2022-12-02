using Common.Enum;

namespace Common.Model
{
    public class ResponseBase<T>
    {
        public ResponseTypeEnum ResponseType { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
    public class ResponseModel
    {
    }
}
