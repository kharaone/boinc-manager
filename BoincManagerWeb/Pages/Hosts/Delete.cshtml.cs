﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoincManager.Models;
using BoincManagerWeb.Models;

namespace BoincManagerWeb.Pages.Hosts
{
    public class DeleteModel : PageModel
    {
        private readonly BoincManagerWeb.Models.ApplicationDbContext _context;

        public DeleteModel(BoincManagerWeb.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Host Host { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Host = await _context.Host.FirstOrDefaultAsync(m => m.Id == id);

            if (Host == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Host = await _context.Host.FindAsync(id);

            if (Host != null)
            {
                _context.Host.Remove(Host);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}