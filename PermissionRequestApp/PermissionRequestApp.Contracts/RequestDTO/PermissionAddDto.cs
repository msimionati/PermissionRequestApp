﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionRequestApp.Contracts.RequestDTO
{
    public class PermissionAddDto
    {
        public int PermissionTypeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime Date { get; set; }
    }
}
