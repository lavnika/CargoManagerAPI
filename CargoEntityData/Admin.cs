using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoEntity
{
    /// <summary>
    /// Represents an administrator in the system.
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// Gets or sets the unique identifier for the administrator.
        /// </summary>
        [Key]
        
        public int AdminId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the administrator.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the administrator.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the unique username of the administrator.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password associated with the administrator's account.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the email address of the administrator.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number associated with the administrator.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string? PhoneNo { get; set; }
    }
}

