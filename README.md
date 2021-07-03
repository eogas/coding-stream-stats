# Coding Stream Stats

I wanted to know when the best time to host a coding stream would be,
so I set up this little project to help track some stats for me.

## Authentication

This project uses Twitch's [OAuth client credentials flow](https://dev.twitch.tv/docs/authentication/getting-tokens-oauth/#oauth-client-credentials-flow) for authentication. Reference the twitch docs first to create an app, then get the Client Id and generate a Client Secret for the app. In the example below, we will use the placeholder value "abcd1234" for both the Client Id and Secret.

Once we have a Client Id and Secret, they can be configured on the local dev environment using the dotnet [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets):

```
dotnet user-secrets init
dotnet user-secrets set "TwitchConnection:ClientId" "abcd1234"
dotnet user-secrets set "TwitchConnection:ClientSecret" "abcd1234"
```
