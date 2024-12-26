namespace VCodify.Models
{
    public class ApiResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
}
