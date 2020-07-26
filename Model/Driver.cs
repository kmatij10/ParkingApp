using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.Model
{
    public class Driver: AppModel
    {
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; }

        [Required]
        public long CarId { get; set; }
        
        // public Car Car { get; set; }

    }
}