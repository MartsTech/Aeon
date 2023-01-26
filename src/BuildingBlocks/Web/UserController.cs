using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace BuildingBlocks.Web;

[Authorize]
[RequiredScope("User.Scope")]
public abstract class UserController: BaseController
{
}