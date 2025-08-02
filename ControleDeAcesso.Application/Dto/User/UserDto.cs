namespace AccessControl.Application.Dto
{
    public record UserDto(string Id, long ContaId, string Name, string UserName, string UserType, string Photo, string Email);
}
