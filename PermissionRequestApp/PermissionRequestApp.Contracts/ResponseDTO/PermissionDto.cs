using PermissionRequestApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionRequestApp.Contracts.ResponseDTO
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public int PermissionTypeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime Date { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}

