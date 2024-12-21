using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoEntity
{
    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        [Key]
        
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the unique username of the customer.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password associated with the customer's account.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number associated with the customer.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string? PhoneNo { get; set; }
    }
}
