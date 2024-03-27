using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();
            byte[] bytes = null;
            if (emptyStudent.ImageFile != null)
            {
                using Stream fs = emptyStudent.ImageFile.OpenReadStream();
                {
                    Console.WriteLine(fs);
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        bytes = reader.ReadBytes((Int32)fs.Length);
                    }
                }
                Student.StudentImageData = Convert.ToBase64String(bytes, 0, bytes.Length);
                Console.WriteLine($"Check Base64String total:{Student.StudentImageData}");
            }


                if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate, s => s.Year, s => s.StudentImageData))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
