using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }

        // Get for Pet Owners
         [HttpGet]
         public IEnumerable<PetOwner> GetPetOwners(){
             return _context.PetOwner;
         }
        // POST
        [HttpPost]
         public IActionResult CreatePetOwner(PetOwner petOwner){
             _context.Add(petOwner); // INSERT into Petowner
             _context.SaveChanges(); //Save changes

            return CreatedAtAction(nameof(CreatePetOwner), new {id = petOwner.Id}, petOwner);
         }
        //  UPDATE

        // DELETE 
        [HttpDelete("id")]
         public IActionResult DeletePetOwner(int id){
            // find the Id to delete:
            PetOwner petOwner = _context.PetOwner.Find(id);
            // Remove  
            _context.PetOwner.Remove(petOwner);
            // Save changes
            _context.SaveChanges();    
            // Send an Ok status
            return Ok(); 
         }
    }
}
