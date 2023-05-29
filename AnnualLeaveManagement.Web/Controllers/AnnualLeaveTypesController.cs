using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnnualLeaveManagement.Web.Data;
using AutoMapper;
using AnnualLeaveManagement.Web.Models;

namespace AnnualLeaveManagement.Web.Controllers
{
    public class AnnualLeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnnualLeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: AnnualLeaveTypes
        public async Task<IActionResult> Index()
        {
            /*return _context.AnnualLeaveTypes != null ? 
                        View(await _context.AnnualLeaveTypes.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.AnnualLeaveTypes'  is null.");*/
            var leaveTypes = _mapper.Map<List<LeaveTypeViewModel>>(await _context.AnnualLeaveTypes.ToListAsync());
            return View(leaveTypes);
        }

        // GET: AnnualLeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnnualLeaveTypes == null)
            {
                return NotFound();
            }

            var annualLeaveType = await _context.AnnualLeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annualLeaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(annualLeaveType);
            return View(leaveTypeViewModel);
        }

        // GET: AnnualLeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualLeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<AnnualLeaveType>(leaveTypeViewModel);
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: AnnualLeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnnualLeaveTypes == null)
            {
                return NotFound();
            }

            var annualLeaveType = await _context.AnnualLeaveTypes.FindAsync(id);
            if (annualLeaveType == null)
            {
                return NotFound();
            }
            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(annualLeaveType);
            return View(leaveTypeViewModel);
        }

        // POST: AnnualLeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeViewModel leaveTypeViewModel)
        {
            if (id != leaveTypeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<AnnualLeaveType>(leaveTypeViewModel);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnualLeaveTypeExists(leaveTypeViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: AnnualLeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnnualLeaveTypes == null)
            {
                return NotFound();
            }

            var annualLeaveType = await _context.AnnualLeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annualLeaveType == null)
            {
                return NotFound();
            }

            return View(annualLeaveType);
        }

        // POST: AnnualLeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnnualLeaveTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnnualLeaveTypes'  is null.");
            }
            var annualLeaveType = await _context.AnnualLeaveTypes.FindAsync(id);
            if (annualLeaveType != null)
            {
                _context.AnnualLeaveTypes.Remove(annualLeaveType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnualLeaveTypeExists(int id)
        {
          return (_context.AnnualLeaveTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
