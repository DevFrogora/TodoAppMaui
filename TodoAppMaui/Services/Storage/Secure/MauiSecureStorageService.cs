namespace TodoAppMaui.Services.Storage.Secure;

class MauiSecureStorageService : ISecureStorageService
{
    public async Task Save(string key, string value)
    {
        await SecureStorage.Default.SetAsync(key, value);
    }

    public async Task<string> Get(string key)
    {
        return await SecureStorage.Default.GetAsync(key);
    }
}
