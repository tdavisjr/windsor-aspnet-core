using WcfService.DataContract;

namespace WcfServiceHost
{

    public class HelloService : IHelloService
    {
        public string SayHello(string firstName)
        {
            return $"Hello {firstName}";
        }
    }
}