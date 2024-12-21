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
    /// Represents a cargo order in the system.
    /// </summary>
    public class CargoOrder
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cargo order.
        /// </summary>
        [Key]
        
        public int CargoOrderId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the customer placing the order.
        /// </summary>
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the order.
        /// </summary>
        

        /// <summary>
        /// Gets or sets the foreign key referencing the type of cargo in the order.
        /// </summary>
        [ForeignKey("CargoType")]
        public int CargoTypeId { get; set; }

        /// <summary>
        /// Gets or sets the cargo type associated with the order.
        /// </summary>
        

        /// <summary>
        /// Gets or sets the date when the order was placed.
        /// </summary>
        [Required]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the cargo order.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the location associated with the cargo order.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the cargo in the order.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the product in the order.
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product associated with the order.
        /// </summary>
        

    }
}
