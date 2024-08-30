using ABCretailApp.Services;
using Microsoft.AspNetCore.Mvc;
using SemesterTwo.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Part1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlobService blobService; private readonly TableService tableService; private readonly QueueService queueService; private readonly FileService fileService;

        public HomeController(BlobService blobService, TableService tableService, QueueService queueService, FileService fileService)
        {
            blobService = blobService;
            tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            queueService = queueService;
            fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await blobService.UploadBlobAsync("product-images", file.FileName, stream);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
        {
            if (ModelState.IsValid)
            {
                await tableService.AddEntityAsync(profile); 
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderId)
        {
            await queueService.SendMessageAsync("order-processing", $"Processing order {orderId}");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadContract(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await fileService.UploadFileAsync("contracts-logs", file.FileName, stream);
            }
            return RedirectToAction("Index");
        }
    }
}





