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
    /// Represents a cargo booking in the system.
    /// </summary>
    public class CargoBooking
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cargo booking.
        /// </summary>
        [Key]
        
        public int CargoBookingId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the cargo fare associated with the booking.
        /// </summary>
        [ForeignKey("CargoFare")]
        public int CargoFareID { get; set; }

        /// <summary>
        /// Gets or sets the cargo fare associated with the booking.
        /// </summary>
       

        /// <summary>
        /// gets or sets the foreign key referencing the cargo order details for the booking.
        /// </summary>
        [ForeignKey("cargoorderdetails")]
        public int cargoorderid { get; set; }

        /// <summary>
        /// gets or sets the cargo order details associated with the booking.
        /// </summary>
        

        /// <summary>
        /// Gets or sets the date when the booking was made.
        /// </summary>
        [Required]
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the cargo booking.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string? BookingStatus { get; set; }

       
    }
}
