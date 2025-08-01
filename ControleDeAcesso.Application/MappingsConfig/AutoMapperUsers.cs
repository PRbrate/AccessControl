using AccessControl.Application.Dto;
using AccessControl.Domain.Entites;

namespace AccessControl.Application.MappingsConfig
{
    public static class AutoMapperUsers
    {

        public static User Map(this RegisterUserDto user) => new()
        {
            Name = user.Name,
            Adress = user.Adress,
            UserName = user.UserName,
            City = user.City,
            State = user.State,
            PostalCode = user.PostalCode,
            Email = user.Email,
            PasswordHash = user.Password,
        };

    }
}
