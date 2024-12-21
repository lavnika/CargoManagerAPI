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
    /// Represents a warehouse in the system.
    /// </summary>
    public class WareHouse
    {
        /// <summary>
        /// Gets or sets the unique identifier for the warehouse.
        /// </summary>
        [Key]
        
        public int WareHouseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the warehouse.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? WareHouseName { get; set; }

        /// <summary>
        /// Gets or sets the stock status of the warehouse.
        /// </summary>
        [Required]
        public bool StockStatus { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the warehouse.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the address of the warehouse.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the cargo order associated with the warehouse.
        /// </summary>
        //[ForeignKey("CargoOrder")]
        //public int CargoOrderId { get; set; }

        /// <summary>
        /// Gets or sets the cargo order associated with the warehouse.
        /// </summary>
        public CargoOrder? CargoOrder { get; set; }

        [ForeignKey("CargoBooking")]
        public int CargoBookingId { get; set; }
        public CargoBooking? CargoBooking { get; set; }
    }
}
