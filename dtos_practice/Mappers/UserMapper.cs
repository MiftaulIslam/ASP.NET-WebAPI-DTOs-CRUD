using dtos_practice.Models.Domains;
using dtos_practice.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace dtos_practice.Mappers
{
    public class UserMapper
    {
        //UserModel to UserCreateDTO 
        public UserCreateDTO UserMapToCreateDTO(UserModel user)
        {
            return new UserCreateDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
            };
        }
        //UserModel to UserReadDTO
        public UserReadDTO UserMapToReadDTO(UserModel user) {
            return new UserReadDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Contact = user.Contact
            };
        }
        
        //UserModel to UserUpdateDTO

        public UserUpdateDTO UserMapToUpdateDTO(UserModel user)
        {
            return new UserUpdateDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Contact = user.Contact,

            };
        }
        
        //UserModel to UserListDTO

        public UserUpdateDTO UserMapToListDTO(UserModel user)
        {
            return new UserUpdateDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Contact = user.Contact,

            };
        }
        
        //UserCreateDTO to UserModel

        public UserModel UserMapToModel(UserCreateDTO createDTO)
        {
            return new UserModel
            {
                FirstName = createDTO.FirstName,
                LastName = createDTO.LastName,
                Email = createDTO.Email,
                Password = createDTO.Password
            };
        }

        //UserUpdateDTO to UserModel
        public UserModel UserMapToModel(UserUpdateDTO updateDTO)
        {
            return new UserModel
            {
                Id = updateDTO.Id,
                FirstName = updateDTO.FirstName,
                LastName = updateDTO.LastName,
                Email = updateDTO.Email,
                Password = updateDTO.Password,
                Contact = updateDTO.Contact,
            };
        }
    }
}
