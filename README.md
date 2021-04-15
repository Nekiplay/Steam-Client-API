# Steam-Client-API
API for Desktop Steam

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/dd1774b107464d3e9f4805df8ecdf135)](https://www.codacy.com/gh/Nekiplay/Steam-Client-API/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Nekiplay/Steam-Client-API&amp;utm_campaign=Badge_Grade)

## Using Steam Client API

**Example:**
```C#
SteamClientAPI.SteamClientAPI.Profile profile = new SteamClientAPI.SteamClientAPI.Profile();
Console.WriteLine("Balance: " + profile.Balance + " " + profile.Currency);
```

**Example with exceptions:**
```C#
SteamClientAPI.SteamClientAPI.Profile profile = new SteamClientAPI.SteamClientAPI.Profile();
try
{
    Console.WriteLine("Balance: " + profile.Balance + " " + profile.Currency);
}
catch (SteamClientAPI.Exceptions.Steam ex)
{
    Console.WriteLine(ex.SteamExeption);
}
```
