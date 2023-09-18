using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICoverLetterGenerator _coverLetterGenerator;

        public IndexModel(ICoverLetterGenerator coverLetterGenerator)
        {
            _coverLetterGenerator = coverLetterGenerator;
        }

        public async Task OnGet()
        {
            //pretend that this is our unique identifier for user (e.g. id or email address, and that user has authenticated)
            string userName = Request.Query["user"];

            if (!String.IsNullOrEmpty(userName))
            {
                _coverLetterGenerator.GenerateCoverLetter(userName);
            }
            


        }
    }
}