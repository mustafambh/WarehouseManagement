namespace WarehouseManagement.Application.Common
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public int Number {  get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
    }
}
