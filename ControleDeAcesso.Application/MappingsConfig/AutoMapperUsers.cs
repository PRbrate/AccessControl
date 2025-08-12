using AccessControl.Application.Dto;
using AccessControl.Domain.Entites;
using AccessControl.Domain.Entites.Enums;

namespace AccessControl.Application.MappingsConfig
{
    public static class AutoMapperUsers
    {

        public static User Map(this RegisterUserDto user) => new()
        {
            Name = user.Name,
            Adress = user.Adress,
            UserName = user.UserName,
            UserType = UserType.Costumer,
            City = user.City,
            State = user.State,
            PostalCode = user.PostalCode,
            Email = user.Email,
            PasswordHash = user.Password,
            Photo = user.Photo
        };

        public static UserDto Map(this User user) => new(
            user.Id,
            user.ContaId,
            user.Name,
            user.UserName,
            user.UserType.ToString(),
            user.Photo,
            user.Email
        );

    }
}
