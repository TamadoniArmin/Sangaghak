namespace SangaghakWebApiEndPoint.WebFramework.ApiHelper
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public string? Massage { get; set; }
    }
    public class ApiResult<T1,T2,T3> : ApiResult
    { 
        public T1? Result1 { get; set; }
        public T2? Result2 { get; set; }
        public T3? Result3 { get; set; }
    }
}
