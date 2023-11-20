using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca_API.models.Dto;

namespace Biblioteca_API.Controller
{
    [ApiController]
    [Route("supplier")]
    public class SupplierController : ControllerBase
    {
        private BibliotecaDbContext _context;

        public SupplierController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewSupplier([FromBody] Supplier supplier)
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (supplier == null)
                return BadRequest();

            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return Created("Adicionado novo fornecedor", supplier);
        }

        [HttpGet]
        [Route("current")]
        public async Task<ActionResult<IEnumerable<Supplier>>> SearchSupplier()
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();

            var suppliers = await _context.Supplier
                .Where(supplier => supplier.ContractStatus)
                .ToListAsync();

            return Ok(suppliers);
        }

        [HttpGet]
        [Route("name")]
        public async Task<ActionResult<IEnumerable<Supplier>>> FindSupplierByName(string name)
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (name is null)
                return BadRequest();

            return await _context.Supplier
                .Where(supplier => supplier.Name.Equals(name))
                .ToListAsync();

        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Supplier>> FindSupplierById(int id)
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (id <= 0)
                return BadRequest();

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier is null)
                return NotFound();

            return supplier;
        }

        [HttpPut]
        [Route("modify")]
        public async Task<ActionResult<Supplier>> ModifySupplier([FromForm] Supplier supplier)
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (supplier is null)
                return BadRequest();

            _context.Supplier.Update(supplier);
            await _context.SaveChangesAsync();
            return Ok(supplier);
        }

        [HttpPatch]
        [Route("modify-contract")]
        public async Task<ActionResult<Supplier>> ChangeSupplierContract([FromBody] SupplierContract supplierContract)
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (supplierContract.id <= 0) 
                return BadRequest("Id indicado fora do range!");
            
            var supplier = await _context.Supplier.FindAsync(supplierContract.id);
            if (supplier is null)
                return NotFound();
            supplier.ContractStatus = supplierContract.contractStatus;

            if (supplierContract.contractStart.HasValue)
                supplier.ContractStart = supplierContract.contractStart.Value;
            if (supplierContract.contractEnd.HasValue)
                supplier.ContractEnd = supplierContract.contractEnd.Value;

            _context.Supplier.Update(supplier);
            await _context.SaveChangesAsync();
            return Ok(supplier);
        }

        [HttpDelete]
        [Route("delete-inactive")]
        public async Task<ActionResult> DeleteSupplier([Required] int id)
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (id <= 0)
                return BadRequest("ID indicado fora do range!");

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier is null)
                return NotFound();
            if (supplier.ContractStatus)
                return StatusCode(403, "Impossível deletar um fornecedor com contrato ativo!");

            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
