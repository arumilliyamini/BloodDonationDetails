using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodDonationDetails.Models;
using System.Xml.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using BloodDonationDetails.Models;

namespace BloodDonationDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidateDetailsController : ControllerBase
    {
        private readonly DonationDbContext _context;

        public DonationCandidateDetailsController(DonationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonationCandidateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationCandidateDetails>>> GetcandidateDetails()
        {

            return await _context.candidateDetails.ToListAsync();
        }

        // GET: api/DonationCandidateDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCandidateDetails>> GetDonationCandidateDetails(int id)
        {
            var donationCandidateDetails = await _context.candidateDetails.FindAsync(id);

            if (donationCandidateDetails == null)
            {
                return NotFound();
            }
            // Convert the object to JSON
            var jsonString = JsonSerializer.Serialize(donationCandidateDetails);

            // Convert JSON to XML
            var xmlString = JsonToXml(jsonString);

            return Content(xmlString, "application/xml");

            // return donationCandidateDetails;
        }

        private string JsonToXml(string json)
        {
            var doc = JsonDocument.Parse(json);
            var root = new XElement("Root", ConvertJsonToXml(doc.RootElement));
            return root.ToString();
        }
        private XElement ConvertJsonToXml(JsonElement jsonElement)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                    var obj = new XElement("Object");
                    foreach (var property in jsonElement.EnumerateObject())
                    {
                        obj.Add(new XElement(property.Name, ConvertJsonToXml(property.Value)));
                    }
                    return obj;

                case JsonValueKind.Array:
                    var array = new XElement("Array");
                    foreach (var item in jsonElement.EnumerateArray())
                    {
                        array.Add(ConvertJsonToXml(item));
                    }
                    return array;

                case JsonValueKind.String:
                    return new XElement("String", jsonElement.GetString());

                case JsonValueKind.Number:
                    return new XElement("Number", jsonElement.GetDecimal());

                case JsonValueKind.True:
                case JsonValueKind.False:
                    return new XElement("Boolean", jsonElement.GetBoolean());

                case JsonValueKind.Null:
                    return new XElement("Null");

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // PUT: api/DonationCandidateDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationCandidateDetails(int id, DonationCandidateDetails donationCandidateDetails)
        {
            //if (id != donationCandidateDetails.DonatedpersonID)
            //{
            //    return BadRequest();
            //}
            donationCandidateDetails.DonatedpersonID = id;
            _context.Entry(donationCandidateDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationCandidateDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DonationCandidateDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonationCandidateDetails>> PostDonationCandidateDetails(DonationCandidateDetails donationCandidateDetails)
        {
            _context.candidateDetails.Add(donationCandidateDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonationCandidateDetails", new { id = donationCandidateDetails.DonatedpersonID }, donationCandidateDetails);
        }

        // DELETE: api/DonationCandidateDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonationCandidateDetails(int id)
        {
            var donationCandidateDetails = await _context.candidateDetails.FindAsync(id);
            if (donationCandidateDetails == null)
            {
                return NotFound("The User Details Not Found");
            }

            _context.candidateDetails.Remove(donationCandidateDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonationCandidateDetailsExists(int id)
        {
            return _context.candidateDetails.Any(e => e.DonatedpersonID == id);
        }
    }
}

