namespace BlazorServer.Constants;

public static class ApplicationPermissions
{
    public static List<string> GetAdminPermissions()
    {
        var permissions = new List<string>
        {
            $"{nameof(HostRecord)}.Create",
            $"{nameof(HostRecord)}.Read",
            $"{nameof(HostRecord)}.Update",
            $"{nameof(HostRecord)}.Delete",
            $"{nameof(GuestRecord)}.Create",
            $"{nameof(GuestRecord)}.Read",
            $"{nameof(GuestRecord)}.Update",
            $"{nameof(GuestRecord)}.Delete",
            $"{nameof(CaseRecord)}.Create",
            $"{nameof(CaseRecord)}.Read",
            $"{nameof(CaseRecord)}.Update",
            $"{nameof(CaseRecord)}.Delete",
            $"{nameof(AddressRecord)}.Create",
            $"{nameof(AddressRecord)}.Read",
            $"{nameof(AddressRecord)}.Update",
            $"{nameof(AddressRecord)}.Delete",
            $"{nameof(GuestChild)}.Create",
            $"{nameof(GuestChild)}.Read",
            $"{nameof(GuestChild)}.Update",
            $"{nameof(GuestChild)}.Delete",
            $"{nameof(HomeVisitRecord)}.Create",
            $"{nameof(HomeVisitRecord)}.Read",
            $"{nameof(HomeVisitRecord)}.Update",
            $"{nameof(HomeVisitRecord)}.Delete",
            $"{nameof(CaseInvolvement)}.Create",
            $"{nameof(CaseInvolvement)}.Read",
            $"{nameof(CaseInvolvement)}.Update",
            $"{nameof(CaseInvolvement)}.Delete",
            "ApplicationUser.Create",
            "ApplicationUser.Read",
            "ApplicationUser.Update",
            "ApplicationUser.Delete",
        };
        return permissions;
    }
    
    public static List<string> GetCaseWorkerPermissions()
    {
        var permissions = new List<string>
        {
            $"{nameof(HostRecord)}.Read",
            $"{nameof(HostRecord)}.Update",
            $"{nameof(GuestRecord)}.Read",
            $"{nameof(GuestRecord)}.Update",
            $"{nameof(CaseRecord)}.Read",
            $"{nameof(AddressRecord)}.Read",
            $"{nameof(AddressRecord)}.Update",
            $"{nameof(GuestChild)}.Read",
            $"{nameof(GuestChild)}.Update",
            $"{nameof(HomeVisitRecord)}.Read",
            $"{nameof(HomeVisitRecord)}.Update",
            $"{nameof(CaseInvolvement)}.Read",
            $"{nameof(CaseInvolvement)}.Update",
            "ApplicationUser.Read"
        };
        return permissions;
        
    }
    
    public static List<string> GetReadOnlyPermissions()
    {
        var permissions = new List<string>
        {
            $"{nameof(HostRecord)}.Read",
            $"{nameof(GuestRecord)}.Read"
        };
        return permissions;
    }
}