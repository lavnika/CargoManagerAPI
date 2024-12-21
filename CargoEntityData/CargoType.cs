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
    /// Represents a type of cargo in the system.
    /// </summary>
    public class CargoType
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cargo type.
        /// </summary>
        [Key]
        
        public int CargoTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cargo type.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? TypeName { get; set; }
    }
}
