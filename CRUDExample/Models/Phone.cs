using System.ComponentModel.DataAnnotations;

namespace CRUDExample.Models
{
    public class Phone
    {
        [Key]
        public string SerialNumber { get; set; } = null!;

        /// <summary>
        /// The model of the phone
        /// ex. Samsung Galaxy S20
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// The type of phone
        /// ex. Flip, smartphone, foldable
        /// </summary>
        public string Type { get; set; } = "Smart";

        /// <summary>
        /// Retail price of the phone
        /// </summary>
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        /// <summary>
        /// Size of screen measured diagonally
        /// in inches
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Color of the phone
        /// </summary>
        public string Color { get; set; } = null!;

        public double GetPhoneSizeInCentimeters()
        {
            throw new NotImplementedException();
        }
    }
}
