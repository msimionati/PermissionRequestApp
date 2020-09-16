using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PermissionRequestApp.Contracts;
using PermissionRequestApp.Contracts.RequestDTO;
using PermissionRequestApp.Contracts.ResponseDTO;
using PermissionRequestApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionTypeRequestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PermissionTypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
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
                var permissionTypes = await _repository.PermissionType.GetAllAsync();
                _logger.LogInfo($"Returned all permissions types from database.");
                var permissionsResult = _mapper.Map<IEnumerable<PermissionTypeDto>>(permissionTypes);
                return Ok(permissionsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllpermissions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "PermissionTypeById")]
        public async Task<IActionResult> GetPermissionTypeById(int id)
        {
            try
            {
                var permissionType = await _repository.PermissionType.GetByIdAsync(id);
                if (permissionType == null)
                {
                    _logger.LogError($"PermissionType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned permission with id: {id}");
                    var permissionResult = _mapper.Map<PermissionTypeDto>(permissionType);
                    return Ok(permissionResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPermissionTypeById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissionType([FromBody] PermissionTypeAddDto permissionType)
        {
            try
            {
                if (permissionType == null)
                {
                    _logger.LogError("PermissionType object sent from client is null.");
                    return BadRequest("PermissionType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid permission type object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var permissionTypeEntity = _mapper.Map<PermissionType>(permissionType);
                _repository.PermissionType.Create(permissionTypeEntity);
                await _repository.SaveAsync();
                var createdPermissionType = _mapper.Map<PermissionTypeDto>(permissionTypeEntity);
                return CreatedAtRoute("PermissionTypeById", new { id = createdPermissionType.Id }, createdPermissionType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePermissionType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermissionType(int id, [FromBody] PermissionTypeUpdateDto permissionType)
        {
            try
            {
                if (permissionType == null)
                {
                    _logger.LogError("PermissionType object sent from client is null.");
                    return BadRequest("PermissionType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid permission object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var permissionTypeEntity = await _repository.PermissionType.GetByIdAsync(id);
                if (permissionTypeEntity == null)
                {
                    _logger.LogError($"PermissionType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(permissionType, permissionTypeEntity);
                _repository.PermissionType.Update(permissionTypeEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePermissionType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionType(int id)
        {
            try
            {
                var permissionType = await _repository.PermissionType.GetByIdAsync(id);
                if (permissionType == null)
                {
                    _logger.LogError($"PermissionType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.PermissionType.Delete(permissionType);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePermissionType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
