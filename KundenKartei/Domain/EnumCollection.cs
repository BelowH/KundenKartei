namespace KundenKartei.Domain;

public static class EnumCollection
{
    public enum MessageBoxResult
    {
        Yes,
        No,
        OK,
        Cancel
    }
    
    public enum MessageBoxType
    {
        Ok,
        OkCancel,
        YesNo,
        YesNoCancel,
    }

    public enum SubMask
    {
        NewCustomer,
        CustomerDetail,
        NewEvent,
    }
    
    
    
}