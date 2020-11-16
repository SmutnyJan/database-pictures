using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pic;
using pic.Data;

namespace pic.Pages
{
    public class CreateModel : PageModel
    {
        private readonly pic.Data.ApplicationDbContext _context;

        public CreateModel(pic.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Picture Picture { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Picture pic = new Picture();
            if (Request.Form.Files.Count == 1)
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    var size = file.Length;
                    var type = file.ContentType;
                    var filename = file.FileName;
                    MemoryStream ims = new MemoryStream();
                    MemoryStream oms1 = new MemoryStream();
                    file.CopyTo(ims);
                    pic.PictureImage = ims.ToArray();
                    pic.PictureImageType = type;
                }
            }
            _context.Pictures.Add(Picture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
