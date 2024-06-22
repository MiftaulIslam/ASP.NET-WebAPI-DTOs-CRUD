using dtos_practice.Mappers;
using dtos_practice.Models.Domains;
using dtos_practice.Models.DTOs.UserDTOs;
using dtos_practice.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dtos_practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericCrud<UserModel> _repository;
        private readonly UserMapper _mapper;
        public UserController(IGenericCrud<UserModel> repository, UserMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> GetUsers()
        {
            try
            {

                var users = await _repository.GetAllAsync();
                return Ok(users.Select(u => _mapper.UserMapToListDTO(u)));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error Retrive Users:{ex.Message}");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id) {

            try
            {
                var user = await _repository.GetByIdAsync(id);
                return Ok(_mapper.UserMapToReadDTO(user));
            }catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDTO>> CreateUser(UserCreateDTO user) {

            try
            {
                if (!ModelState.IsValid) {  return BadRequest(); }
                var userModel = _mapper.UserMapToModel(user);
                await _repository.CreateAsync(userModel);
                return CreatedAtAction(nameof(GetUserById), new { id = userModel.Id }, _mapper.UserMapToReadDTO(userModel));
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDTO>> UpdateUser(int id,UserUpdateDTO user) {

            try
            {
                if (!ModelState.IsValid) {  return BadRequest(); }
                var userModel = _mapper.UserMapToModel(user);
                await _repository.UpdateAsync(id,userModel);
                return Ok("User Updated successfully");
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDTO>> DeleteUser(int id) {

            try
            {
                await _repository.DeleteAsync(id);
                return Ok("User Deleted successfully");
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
