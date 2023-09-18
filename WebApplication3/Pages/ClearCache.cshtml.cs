using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class ClearCacheModel : PageModel
    {
        private readonly ICoverLetterGenerator _coverLetterGenerator;

        public ClearCacheModel(ICoverLetterGenerator coverLetterGenerator)
        {
            _coverLetterGenerator = coverLetterGenerator;
        }

        public async Task OnGet()
        {
            _coverLetterGenerator.ClearCache();
         
        }
    }
}