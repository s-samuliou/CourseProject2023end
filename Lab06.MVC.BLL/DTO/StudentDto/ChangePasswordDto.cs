namespace Lab06.MVC.BLL.DTO
{
    public  class ChangePasswordDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string OldPassword { get; set; }
    }
}