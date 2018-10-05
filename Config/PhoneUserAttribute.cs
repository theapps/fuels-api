using api.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Config
{
    public class PhoneUserAttribute: ActionFilterAttribute
    {
        private IUserService _userService;

        public PhoneUserAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var phone = context?.HttpContext?.Request?.Headers?["phone"];
            if (!string.IsNullOrWhiteSpace( phone))
            {

                _userService.SetCurrentUser(phone);
            }
            base.OnActionExecuting(context);
        }
    }
}