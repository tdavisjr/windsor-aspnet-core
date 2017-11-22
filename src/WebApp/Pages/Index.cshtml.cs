using Company.Project.HelloClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
		// *** Replaced by connected service ***
		//private readonly IHelloService _helloService;

		// *** Connected Service ***
		private readonly HelloServiceClient _helloService;

		public string HelloMessage { get; set; }

        public IndexModel
		(
			// *** Replaced by connected service *** 
			// IHelloService helloService
			
			// *** Connected Service ***
			HelloServiceClient client
		)
		{
			// *** Replaced by connected service ***
			//_helloService = helloService;

			// *** Connected Service ***
			_helloService = client;

		}

		// TODO: Make this async/await
		public void OnGet()
        {
			// *** Replaced by connected service ***
			// HelloMessage = _helloService.SayHello("Tyrone");
	        
			// *** Connected Service ***
	        HelloMessage = _helloService.SayHelloAsync("Tyrone").GetAwaiter().GetResult();
        }
	}
}
