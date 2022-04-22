using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.ClientService.Contracts.Complaints;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.EntityContracts.Enums;

namespace TradingPlatform.ClientService.Presentation
{
    public class ComplaintsController: Controller
    {
        private readonly IComplaintService _complaintService;
        public ComplaintsController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        // GET: Complaints
        public async Task<IActionResult> Index()
        {
            return View(await _complaintService.IndexAsync());
        }

        // GET: Complaints/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _complaintService.DetailsAsync(id));
        }

        // GET: Complaints/Create
        public IActionResult Create(int productId)
        {
            return View(_complaintService.CreateGetAsync(productId));
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComplaintCreateViewModel complaintCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _complaintService.CreatePostAsync(complaintCreateViewModel.ComplaintCreate);
                if (User.IsInRole(UserRoles.Admin))
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index),"Home");
            }

            complaintCreateViewModel.ComplaintTypes = new SelectList(Enum.GetValues(typeof(ComplaintType))
                .Cast<ComplaintType>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int) v).ToString()
                }).ToList(), "Value", "Text");
            return View(complaintCreateViewModel);
        }

        // GET: Complaints/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _complaintService.EditGetAsync(id));
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ComplaintEditViewModel complaintEditViewModel)
        {
            if (ModelState.IsValid)
            {
                await _complaintService.EditPostAsync(id, complaintEditViewModel.ComplaintEdit);
                return RedirectToAction(nameof(Index));
            }
            return View(complaintEditViewModel);
        }

        // GET: Complaints/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var complaint = await _complaintService.DetailsAsync(id);

            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _complaintService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
