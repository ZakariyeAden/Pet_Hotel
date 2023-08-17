using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {}
    public enum PetColorType {}
    public class Pet 
    {
        public int Id {get; set;}
        [Required]
        public string Name { get; set; }
        // public string breed?
        // public string color?
        // public DateTime CheckedInAt { get; set;} null?
        [ForeignKey("petOwner")]
        public int OwnerId {get; set;}
        public PetOwner petOwner {get; set; }

    }
}
