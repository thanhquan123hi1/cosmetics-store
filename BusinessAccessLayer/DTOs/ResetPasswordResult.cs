namespace BusinessAccessLayer.DTOs
{
    public class ResetPasswordResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
