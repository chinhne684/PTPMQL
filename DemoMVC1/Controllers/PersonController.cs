using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using DemoMVC1.Models;
using DemoMVC1.Data;
using DemoMVC1.Models.Process;
using System.Data;


namespace DemoMVC1.Controllers
{
    public class PersonController : Controller
    {
        // GET: /HelloWorld
        public IActionResult Inname()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
        public IActionResult Bang()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Bang(Person ps)
        {
            string strOutput = "Xin chao " + ps.PersonId + "-" + ps.FullName + "-" + ps.Address;
            ViewBag.infoPerson = strOutput;
            return View();
        }
        /// <summary>
        /// /////////
        /// 
        /// </summary>
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new excelProcess();

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> Index4()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
        }
        /// <
        /// 
        /// 
        /// 
        /// 
        /// 
        public IActionResult Create()
        {
            var person = new Person();

            // Lấy tất cả PersonId bắt đầu bằng "PS" và đúng 5 ký tự (ví dụ PS001)
            var lastId = _context.Person
                .Where(p => p.PersonId.StartsWith("PS") && p.PersonId.Length == 5)
                .Select(p => p.PersonId)
                .ToList()
                .OrderByDescending(id => id) // sắp xếp giảm dần
                .FirstOrDefault();

            if (lastId != null)
            {
                // Tách phần số từ PS001
                string numberPart = lastId.Substring(2);
                if (int.TryParse(numberPart, out int number))
                {
                    // +1 rồi định dạng lại
                    person.PersonId = "PS" + (number + 1).ToString("D3");
                }
                else
                {
                    person.PersonId = "PS001"; // fallback
                }
            }
            else
            {
                person.PersonId = "PS001"; // bản ghi đầu tiên
            }

            return View(person);
        }

        ////
        /// 
        /// 
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("PersonId, FullName, Address, Email")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index4));
            }
            return View(person);
        }
        /// 
        /// 
        /// 
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id, [Bind("PersonId, FullName, Address, Email")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index4));
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person'  is null.");
            }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index4));
        }


        private bool PersonExists(string id)
        {

            return (_context.Person.Any(e => e.PersonId == id));
        }


        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);

                        //read data from excel file fill DataTable
                        ExcelProcess excelProcess = new ExcelProcess();
                        DataTable dt = excelProcess.ExcelToDataTable(fileLocation);

                        //using for loop to read data from dt
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            //create new Person object
                            var ps = new Person();
                            //set value to attributes
                            ps.PersonId = dt.Rows[i][0].ToString();
                            ps.FullName = dt.Rows[i][1].ToString();
                            ps.Address = dt.Rows[i][2].ToString();
                            //add object to context
                            _context.Add(ps);
                            await _context.SaveChangesAsync();

                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            return View();
        }

    }
}