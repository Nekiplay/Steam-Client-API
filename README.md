# Steam-Client-API
API for Desktop Steam

## Using Steam Client API

**Example:**
```C#
SteamClientAPI.SteamClientAPI.Profile profile = new SteamClientAPI.SteamClientAPI.Profile();
Console.WriteLine("Баланс: " + profile.Balance + " " + profile.Currency);
```

**Example with exceptions:**
```C#
SteamClientAPI.SteamClientAPI.Profile profile = new SteamClientAPI.SteamClientAPI.Profile();
try
{
    Console.WriteLine("Баланс: " + profile.Balance + " " + profile.Currency);
}
catch (SteamClientAPI.Exceptions.Steam ex)
{
    Console.WriteLine(ex.SteamExeption);
}
```
