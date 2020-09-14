using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PermissionRequestApp.Contracts;
using PermissionRequestApp.Contracts.RequestDTO;
using PermissionRequestApp.Contracts.ResponseDTO;
using PermissionRequestApp.Entities.Models;

namespace PermissionRequestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PermissionController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var permissions = await _repository.Permission.GetAllAsync();
                _logger.LogInfo($"Returned all permissions from database.");
                var permissionsResult = _mapper.Map<IEnumerable<PermissionDto>>(permissions);
                return Ok(permissionsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllpermissions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "PermissionById")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            try
            {
                var permission = await _repository.Permission.GetByIdAsync(id);
                if (permission == null)
                {
                    _logger.LogError($"Permission with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned permission with id: {id}");
                    var permissionResult = _mapper.Map<PermissionDto>(permission);
                    return Ok(permissionResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPermissionById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] PermissionAddDto permission)
        {
            try
            {
                if (permission == null)
                {
                    _logger.LogError("Permission object sent from client is null.");
                    return BadRequest("Permission object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid permission object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var permissionEntity = _mapper.Map<Permission>(permission);
                _repository.Permission.Create(permissionEntity);
                await _repository.SaveAsync();
                var createdPermission = _mapper.Map<PermissionDto>(permissionEntity);
                return CreatedAtRoute("PermissionById", new { id = createdPermission.Id }, createdPermission);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePermission action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, [FromBody] PermissionUpdateDto permission)
        {
            try
            {
                if (permission == null)
                {
                    _logger.LogError("Permission object sent from client is null.");
                    return BadRequest("Permission object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid permission object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var permissionEntity = await _repository.Permission.GetByIdAsync(id);
                if (permissionEntity == null)
                {
                    _logger.LogError($"Permission with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(permission, permissionEntity);
                _repository.Permission.Update(permissionEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePermission action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            try
            {
                var permission = await _repository.Permission.GetByIdAsync(id);
                if (permission == null)
                {
                    _logger.LogError($"Permission with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Permission.Delete(permission);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePermission action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
