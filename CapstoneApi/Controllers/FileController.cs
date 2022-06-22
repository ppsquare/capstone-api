
using CapstoneApi.Models;
using CapstoneApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        public FileController()
        {

        }

        [HttpGet]
        public ActionResult<List<MyFile>> GetAll() =>
        FileService.GetAll();

        [HttpGet("{name}, {path}")]
        public ActionResult<MyFile> Get(string name, string path)
        {
            var myFile = FileService.Get(name, path);

            if (myFile == null)
                return NotFound();

            return myFile;
        }

        [HttpPost]
        public IActionResult Create(MyFile myFile)
        {
            FileService.Add(myFile);
            return CreatedAtAction(nameof(Create), new { name = myFile.Name }, myFile);
        }

        /*        // Update the file
                [HttpPut("{name}")]
                public IActionResult Update(string name, MyFile myFile)
                {
                    if (name != myFile.Name)
                        return BadRequest();

                    var existingFile = FileService.Get(name, myFile.Path);
                    if (existingFile is null)
                        return NotFound();

                    FileService.Update(myFile);

                    return NoContent();
                }*/

        // DELETE action
        [HttpDelete("{name}, {path}")]
        public IActionResult Delete(string name, string path)
        {
            var myFile = FileService.Get(name, path);

            if (myFile is null)
                return NotFound();

            FileService.Delete(name, path);

            return NoContent();
        }
    }
}

