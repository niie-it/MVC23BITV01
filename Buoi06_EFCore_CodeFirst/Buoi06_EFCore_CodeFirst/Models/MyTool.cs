namespace Buoi06_EFCore_CodeFirst.Models
{
    public class MyTool
    {
        public static async Task<string> UploadFileToFolder(IFormFile Hinh, string folderName = "products")
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folderName, Hinh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Hinh.CopyToAsync(stream);
                }
                return Hinh.FileName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
