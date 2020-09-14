using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionRequestApp.Entities.Models
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PermissionTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeLastName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(PermissionTypeId))]
        [InverseProperty("Permission")]
        public virtual PermissionType PermissionType { get; set; }
    }
}
