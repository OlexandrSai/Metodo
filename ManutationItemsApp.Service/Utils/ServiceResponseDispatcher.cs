using ManutationItemsApp.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Service.Utils
{
    public static class ServiceResponseDispatcher
    {
        public static IActionResult ExecuteServiceResponse(Controller controller,TypeOfServiceError typeOfServiceError, string message)
        {
            ActionResult result = null;
            switch (typeOfServiceError)
            {
                case TypeOfServiceError.BadRequest:
                    result = controller.BadRequest(message);
                    break;
                case TypeOfServiceError.ConnectionError:
                    result = controller.StatusCode(500, message);
                    break;
                case TypeOfServiceError.NotFound:
                    result = controller.NotFound(message);
                    break;
                case TypeOfServiceError.Unathorized:
                    result = controller.Unauthorized();
                    break;
                case TypeOfServiceError.Forbidden:
                    result = controller.StatusCode(403, message);
                    break;
                case TypeOfServiceError.ServiceError:
                    result = controller.StatusCode(500, message);
                    break;
                default:
                    result = controller.Ok();
                    break;
            }
            return result;
        }
    }
}
