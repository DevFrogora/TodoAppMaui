namespace TodoAppMaui.Services.Storage.Secure;

interface ISecureStorageService
{
    Task Save(string key, string value);
    Task<string> Get(string key);
}
