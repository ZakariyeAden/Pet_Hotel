using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("test")]
        public IEnumerable<Pet> GetPets() {
            PetOwner blaine = new()
            {
                Name = "Blaine"
            };

            Pet newPet1 = new Pet {
                Name = "Big Dog",
                PetOwner = blaine,
                Color = PetColorType.Black,
                Breed = PetBreedType.Poodle,
            };

            Pet newPet2 = new Pet {
                Name = "Little Dog",
                PetOwner = blaine,
                Color = PetColorType.Golden,
                Breed = PetBreedType.Labrador,
            };

            return new List<Pet>{ newPet1, newPet2};
        }
    }
}
