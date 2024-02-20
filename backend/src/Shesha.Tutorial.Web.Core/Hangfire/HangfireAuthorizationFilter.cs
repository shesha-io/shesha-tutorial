using Hangfire.Dashboard;
using Shesha.Authorization;

namespace Shesha.Tutorial.Hangfire
{
    /// <summary>
    /// Hangfire authorization filter: This should be obsolete since Shesha comes with Hangfire Authorization inbuilt
    /// </summary>
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool Authorize(DashboardContext context)
        {
            return context.GetHttpContext().GetUsernameFromJwtToken()?.Trim().ToLower() == "admin";
        }
    }
}
