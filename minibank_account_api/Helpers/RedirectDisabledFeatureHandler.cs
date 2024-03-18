using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace minibank_account_api.Helpers
{
    public class RedirectDisabledFeatureHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden); // Generate a 403.
            return Task.CompletedTask;
        }
    }
}
