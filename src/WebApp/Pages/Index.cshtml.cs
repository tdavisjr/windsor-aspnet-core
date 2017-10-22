using Microsoft.AspNetCore.Mvc.RazorPages;
using WcfService.DataContract;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHelloService _helloService;

        public string HelloMessage { get; set; }

        public IndexModel(IHelloService helloService)
        {
            _helloService = helloService;
        }
        public void OnGet()
        {
            HelloMessage = _helloService.SayHello("Tyrone");
        }


    }
}
