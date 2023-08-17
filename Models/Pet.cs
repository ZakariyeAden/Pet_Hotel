using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public static class PetBreedType {
       public static readonly string Shepherd;
        public static readonly string Poodle;
        public static readonly string Beagle;
        public static readonly string Bulldog;
        public static readonly string Terrier;
        public static readonly string Boxer;
        public static readonly string Labrador;
        public static readonly string Retriever;
    }
    public static class PetColorType {
       public static readonly string White;
        public static readonly String Black;
        public static readonly String Golden;
        public static readonly String Tricolor;
        public static readonly String Spotted;
    }
    public class Pet {

        public string Name {get; set;}

        public string Color {get; set;}

        public DateTime CheckedIn {get;set;}

        public string PetOwner {get; set;}

        public int Id {get;set;}

        public string Breed {get; set;}
    }
}
