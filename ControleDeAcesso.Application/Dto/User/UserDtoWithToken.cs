namespace AccessControl.Application.Dto
{
    public class UserDtoWithToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public UserDto UserDto { get; set; }    }
}
