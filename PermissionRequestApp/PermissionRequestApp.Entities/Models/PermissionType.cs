using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionRequestApp.Entities.Models
{
    public class PermissionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermitTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        [InverseProperty("PermissionType")]
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
