using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pic;
using pic.Data;

namespace pic.Pages
{
    public class ListModel : PageModel
    {
        private readonly pic.Data.ApplicationDbContext _context;

        public ListModel(pic.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Picture> Picture { get;set; }

        public async Task OnGetAsync()
        {
            Picture = await _context.Pictures.ToListAsync();
        }
    }
}
