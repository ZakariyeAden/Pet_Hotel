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

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<Pet> GetPets() {
        //     return new List<Pet>();
        // }

        
        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }

        // Get for Pets by Owner
          [HttpGet]
          public IEnumerable<Pet> GetPets(){
              return _context.Pet
            // Join tables with PetOwner
              .Include(pet => pet.petOwner);
          }

            // GET for Pet by specific ID
         [HttpGet("{id}")]
         public IActionResult GetPetById(int id)
         {
            var pet = _context.Pet.Find(id);
            if(pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
         }

        // POST
        [HttpPost]
        public IActionResult CreatePets (Pet pet){
            _context.Add(pet); // INSERT into pets table
            _context.SaveChanges(); //Save changes 
            return CreatedAtAction(nameof(CreatePets), new {id = pet.Id}, pet);
        }

        // DELETE
        [HttpDelete("id")]
        public IActionResult DeletePets(int id){
            // Find the Id to Delete:
            Pet pet = _context.Pet.Find(id);
            // Remove
            _context.Pet.Remove(pet);
            // Save Changes
            _context.SaveChanges();

            // Send an Ok status
            return Ok(); 
        }

        // PUT
        [HttpPut("{id}/checkin")]
        public IActionResult CheckInPet(int id)
        {
            Pet pet = _context.Pet.Find(id);

            if(pet == null)
            {
                return NotFound();
            }
            if(pet.CheckedInAt == null)
            {
                pet.CheckedInAt = DateTime.Now;

                _context.Update(pet);
                _context.SaveChanges();

                return Ok(pet);
            }
            else
            {
                return BadRequest("Pet is already checked in.");
            }
        }

        [HttpPut("{id}/checkout")]
        public IActionResult CheckOutPet(int id)
        {
            Pet pet = _context.Pet.Find(id);

            if(pet == null)
            {
                return NotFound();
            }
            
            if(pet.CheckedInAt != null)
            {
                pet.CheckedInAt = null;

                _context.Update(pet);
                _context.SaveChanges();

                return Ok(pet);
            }
            else{
                return BadRequest("Pet is already checked out.");
            }
        }


    }
}
