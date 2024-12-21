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
    /// Represents the fare details associated with a cargo shipment in the system.
    /// </summary>
    public class CargoFare
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cargo fare.
        /// </summary>
        [Key]
        public int CargoFareID { get; set; }

        /// <summary>
        /// Gets or sets the source location of the cargo shipment.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? SourceLocation { get; set; }

        /// <summary>
        /// Gets or sets the destination location of the cargo shipment.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? DestinationLocation { get; set; }

        /// <summary>
        /// Gets or sets the weight of the cargo shipment.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the volume of the cargo shipment.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the mode of transport for the cargo shipment.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? ModeOfTransport { get; set; }

        /// <summary>
        /// Gets or sets the date when the cargo shipment is scheduled for shipping.
        /// </summary>
        [Required]
        public DateTime ShippingDate { get; set; }

        /// <summary>
        /// Gets or sets the expected arrival date of the cargo shipment.
        /// </summary>
        [Required]
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets the fare amount for the cargo shipment.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FareAmount { get; set; }

        /// <summary>
        /// Gets or sets additional charges associated with the cargo fare.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AdditionalCharges { get; set; }

        /// <summary>
        /// Gets or sets the total amount including fare and additional charges.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the admin who created the cargo fare.
        /// </summary>
        //[ForeignKey("Admin")]
        //public int? AdminId { get; set; }

        ///// <summary>
        ///// Gets or sets the admin associated with the creation of the cargo fare.
        ///// </summary>
        //public Admin? Admin { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the cargo order associated with the cargo fare.
        /// </summary>
        [ForeignKey("CargoOrder")]
        public int? CargoOrderId { get; set; }

        /// <summary>
        /// Gets or sets the cargo order associated with the cargo fare.
        /// </summary>
        
    }
}
