using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    // * PetBreedType
    // Enum associates each constant (pet breed) with an int for easy referencing
    public enum PetBreedType {
         Shepard, 
         Poodle, 
         Beagle, 
         Bulldog, 
         Terrier, 
         Boxer, 
         Labrador, 
         Retriever
         
    }; // * end PetBreedType
    
    // * PetBreedType
    public enum PetColorType {
        Black,
        White,
        Golden,
        Tricolor,
        Spotted
    }; // * end PetColorType
    public class Pet 
    {
        public int Id {get; set;}
        [Required]
        public string Name { get; set; }
        public string Breed {get; set;}
        public string Color {get; set;}
        public DateTime? CheckedInAt { get; set;}
        [ForeignKey("petOwner")]
        public int OwnerId {get; set;}
        public PetOwner petOwner {get; set; }

    }
}
