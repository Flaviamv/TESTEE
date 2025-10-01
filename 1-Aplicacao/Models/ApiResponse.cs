public class ApiResponse<T>
{

    public ApiResponse() {}
    public ApiResponse(T data)
    {
        this.Data = data;
    }

    public ApiResponse(bool sucess, string? message = null, T data = default)
    {
        this.Success = sucess;
        this.Message = message;
        this.Data = data;
}

    public bool Success { get; set; } = true;
    public T Data { get; set; }
    public string? Message { get; set; }
}