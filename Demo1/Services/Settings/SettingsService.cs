namespace Demo1.Services.Settings;

public class SettingsService : ISettingsService {

    private const string AccessToken = "access_token";

    // private readonly string AccessTokenDefault = string.Empty;
    private readonly string AccessTokenDefault = "anything";

    public string AuthAccessToken
    {
        get => Preferences.Get(AccessToken, AccessTokenDefault);
        set => Preferences.Set(AccessToken, value);
    }
    
}