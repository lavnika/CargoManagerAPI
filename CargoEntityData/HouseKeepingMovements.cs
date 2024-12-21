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
    /// Represents a housekeeping movement associated with cargo, warehouse, and truck exit in the system.
    /// </summary>
    public class HousekeepingMovement
    {
        /// <summary>
        /// Gets or sets the unique identifier for the housekeeping movement.
        /// </summary>
        [Key]
        
        public int HousekeepingMovementId { get; set; }

        
        /// <summary>
        /// Gets or sets the cargo booking associated with the movement.
        /// </summary>
        public CargoBooking? CargoBooking { get; set; }

        /// <summary>
        /// Gets or sets the date when the housekeeping movement occurred.
        /// </summary>
        [Required]
        public DateTime MovementDate { get; set; }

        [ForeignKey("WareHouse")]
        public int WareHouseID { get; set; }
        public WareHouse? WareHouse { get; set; }
    }
}
