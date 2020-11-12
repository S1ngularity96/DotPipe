
namespace DotPipeExample.Handler
{
    public class AdminHandler
    {
        public void LogInAsAdmin(ref DotPipe.PipeContext context) {
            context.Add("LoginStatus", true);
        }
    }
}