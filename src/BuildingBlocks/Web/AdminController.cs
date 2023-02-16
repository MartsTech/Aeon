using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace BuildingBlocks.Web;

[Authorize]
[RequiredScope("Admin.Scope")]
public abstract class AdminController: BaseController
{
}