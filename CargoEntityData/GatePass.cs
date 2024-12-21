using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace CargoEntity
{
    /// <summary>
    /// Represents a gate pass associated with cargo entry and exit in the system.
    /// </summary>
    public class GatePass
    {
       
        public int GatePassNumber { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the gate pass.
        /// </summary>
        
        [Key]
        
        public int GatePassId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key referencing the cargo booking associated with the gate pass.
    /// </summary>
        [ForeignKey("CargoBooking")]
        public int CargoBookingId { get; set; }

        /// <summary>
        /// Gets or sets the cargo booking associated with the gate pass.
        /// </summary>
        

        /// <summary>
        /// Gets or sets the date when the cargo enters the gate.
        /// </summary>
        [Required]
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the cargo exits the gate (nullable if not exited).
        /// </summary>
        public DateTime? ExitDate { get; set; }

        /// <summary>
        /// Gets or sets the type of delivery associated with the gate pass.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? TypeOfDelivery { get; set; }

        
    }
}
