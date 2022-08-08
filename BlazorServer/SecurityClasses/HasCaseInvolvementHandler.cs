namespace BlazorServer.SecurityClasses;

public class HasCaseInvolvementHandler : AuthorizationHandler<HasCaseInvolvementRequirement, CaseRecord>
{
    private readonly AppDbContext _dbContext;

    public HasCaseInvolvementHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, HasCaseInvolvementRequirement requirement, CaseRecord resource)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var hasUserInvolvement = _dbContext.CaseInvolvements
            .Any(x => x.CaseRecordId == resource.Id && x.IsActive && x.UserId == userId);
  
        if (hasUserInvolvement)
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}