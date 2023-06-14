using System.Windows.Input;
using TodoAppMaui.Services.Storage.SharedPreference;

namespace TodoAppMaui.viewmodel;
public class TodoSettingViewModel
{
    private readonly ISharedPreferenceService sharedPreferenceService;

    public TodoSettingViewModel(ISharedPreferenceService sharedPreferenceService)
    {
        this.sharedPreferenceService = sharedPreferenceService;
    }
    public bool IsNotificationChecked
    {
        get
        {
          return sharedPreferenceService.Get<bool>(nameof(IsNotificationChecked),false).Result;
        }
        set {
            sharedPreferenceService.Save(nameof(IsNotificationChecked), value);
        }
    }


    public ICommand ToggleCommand => new Command(SwitchToogle);
    private void SwitchToogle(object obj)
    {
        IsNotificationChecked = (bool)obj;
    }
}
