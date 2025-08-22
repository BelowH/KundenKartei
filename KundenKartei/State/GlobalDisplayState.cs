using System;
using static KundenKartei.Domain.EnumCollection;

namespace KundenKartei.State;

public class GlobalDisplayState
{
    public event EventHandler<SubMask> OnSubMaskChanged;
    
    public event EventHandler<string> OnNavigateToCustomerDetail;

    public event EventHandler OnBack;
    
    
    public void ChangeSubMask(SubMask subMask) => OnSubMaskChanged?.Invoke(this, subMask);
    
    public void NavigateToCustomerDetail( string id) => OnNavigateToCustomerDetail?.Invoke(this, (id));
    
    
    public void Back() => OnBack?.Invoke(this, EventArgs.Empty);
    
    
}