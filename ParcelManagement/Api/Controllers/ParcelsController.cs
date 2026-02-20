using Microsoft.AspNetCore.Mvc;
using ParcelManagement.Application.Interfaces;
using ParcelManagement.Domain.Entities;


namespace ParcelManagement.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ParcelsController : ControllerBase
    {
        private readonly IParcelService _parcelService;


        // Constructor Injection of the service into the controller
        public ParcelsController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        // GET: api/parcels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetAll()
        {
            var parcels = await _parcelService.GetAllParcelsAsync();
            return Ok(parcels);
        }

        // GET: api/parcels/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Parcel>> GetById(Guid id)
        {
            var parcel = await _parcelService.GetParcelByIdAsync(id);

            if (parcel is null)
                return NotFound();

            return Ok(parcel);
        }

        // POST: api/parcels
        [HttpPost]
        public async Task<ActionResult<Parcel>> Create(Parcel parcel)
        {
            try
            {
                var created = await _parcelService.CreateParcelAsync(parcel);

                // Returns 201 Created with Location header
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                // Return 400 Bad Request for validation errors
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
/*   This controller uses Constructor Injection to receive an instance of IParcelService.
  It defines three endpoints:
  - GET /api/parcels: Retrieves all parcels.
  - GET /api/parcels/{id}: Retrieves a parcel by its ID.
  - POST /api/parcels: Creates a new parcel.
  The controller handles basic HTTP responses, including 200 OK, 201 Created, 400 Bad Request, and 404 Not Found.

- Key point: ParcelsController doesn’t know about repository or DB.
-It only depends on IParcelService, injected via constructor.

  */