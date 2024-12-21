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
    /// Represents the exit details of a truck associated with cargo delivery in the system.
    /// </summary>
    public class TruckExit
    {
        /// <summary>
        /// Gets or sets the unique identifier for the truck exit record.
        /// </summary>
        [Key]
       
        public int TruckExitId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the cargo booking associated with the truck exit.
        /// </summary>
        [ForeignKey("CargoBooking")]
        public int CargoBookingId { get; set; }

        /// <summary>
        /// Gets or sets the cargo booking associated with the truck exit.
        /// </summary>
        public CargoBooking? CargoBooking { get; set; }

        /// <summary>
        /// Gets or sets the date when the truck exits the cargo delivery location.
        /// </summary>
        [Required]
        public DateTime ExitDate { get; set; }

        /// <summary>
        /// Gets or sets the reason for the truck exit (nullable if not specified).
        /// </summary>
        public string? Reason { get; set; }
    }
}
