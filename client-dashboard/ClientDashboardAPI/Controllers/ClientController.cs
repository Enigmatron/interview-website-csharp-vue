
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;


// using ClientDashboardAPI.Models;
// using Microsoft.EntityFrameworkCore;

// namespace ClientDashboardAPI.Controllers
// {

//     [ApiController]
//     [Route("api/[controller]")]
//     public class ClientController : ControllerBase
//     {
//         private readonly AppDbContext _context;
//         private readonly ILogger<ClientController> _logger;

//         public ClientController(ILogger<ClientController> logger, AppDbContext context)
//         {
//             _logger = logger;
//             _context = context;
//         }

//         //grabs specific client by client id, since the management page is the only one that grabs a single client, include phone number is included
//         [HttpGet("{id}")]
//         public IActionResult GetClient(int id)
//         {
//             var clients = _context.Clients.Include(c => c.PhoneNumbers).Where(c => c.Id == id).Select(c => new
//             {
//                 c.Id,
//                 c.Name,
//                 c.Email,
//                 c.Company,
//                 c.Address,
//                 PhoneNumbers = c.PhoneNumbers.Select(p => new
//                 {
//                     p.Id,
//                     p.FormattedNumber
//                 })
//             }).FirstOrDefault();
//             if (clients == null)
//                 return NotFound();
//             return Ok(clients);

//         }

//         // grabs all clients, archived or not
//         [HttpGet("all")]
//         public ActionResult<List<Client>> GetAllClients()
//         {
//             //this is bad practice but since this is a demo, pagination and infinite loading is not necessary
//             var clients = _context.Clients.Where(c => true);
//             return Ok(clients);
//         }

//         // grabs all unarchived clients
//         [HttpGet("dashboard")]
//         public ActionResult<List<Client>> GetClients()
//         {
//             var clients = _context.Clients.Where(c => c.Active);
//             return Ok(clients);
//         }

//         [HttpPost("Create")]
//         public ActionResult<Client> CreateClient([FromForm] Client client)
//         {
//             var entry = _context.Clients.Add(client);
//             _context.SaveChanges();
//             return Ok(entry.Entity);

//         }

//         [HttpPut("Update")]
//         public ActionResult UpdateClient(Client client)
//         {
//             var _client = _context.Clients.Include(c => c.PhoneNumbers).Where(c => c.Id == client.Id).FirstOrDefault();

//             if (client == null) return NotFound();

//             _client.Name = client.Name;
//             _client.Email = client.Email;
//             _client.Address = client.Address;
//             _client.Company = client.Company;
//             _client.Active = true;
//             _client.PhoneNumbers = client.PhoneNumbers;
//             _context.SaveChanges();

//             return Ok();

//         }


//         [HttpPost("Archive/{id}")]
//         public ActionResult<Client> ArchiveClient(int id)
//         {
//             var client = _context.Clients.Include(c => c.PhoneNumbers).Where(c => c.Id == id).FirstOrDefault();
//             if (client == null) return NotFound();

//             client.Active = false;
//             _context.SaveChanges();
//             return Ok();

//         }

//     }
// }

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClientDashboardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientDashboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _context.Clients
                .Include(c => c.PhoneNumbers)
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Email,
                    c.Company,
                    c.Address,
                    PhoneNumbers = c.PhoneNumbers.Select(p => new
                    {
                        p.Id,
                        p.FormattedNumber
                    })
                })
                .FirstOrDefaultAsync();

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Client>>> GetAllClients()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            var clients = await _context.Clients.Where(c => c.Active).ToListAsync();
            return Ok(clients);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Client>> CreateClient([FromForm] Client client)
        {
            var entry = await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return Ok(entry.Entity);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            var existingClient = await _context.Clients
                .Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id == client.Id);

            if (existingClient == null) return NotFound();

            existingClient.Name = client.Name;
            existingClient.Email = client.Email;
            existingClient.Address = client.Address;
            existingClient.Company = client.Company;
            existingClient.Active = true;
            existingClient.PhoneNumbers = client.PhoneNumbers;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Archive/{id}")]
        public async Task<ActionResult> ArchiveClient(int id)
        {
            var client = await _context.Clients
                .Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null) return NotFound();

            client.Active = false;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
