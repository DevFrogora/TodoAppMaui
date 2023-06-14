namespace TodoAppMaui.Services.Storage.SharedPreference;

public interface ISharedPreferenceService
{
    Task<T> Get<T>(string key,T defaultValue);
    Task Save<T>(string key, T value);
}
