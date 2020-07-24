using System;
using System.ComponentModel.DataAnnotations;
namespace ParkingApp.Model
{
    public class Car: AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
      
        /*public Car(string Model){
            this.Model = Model;
        }*/
    }
}