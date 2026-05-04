# StravaApiLib

[![NuGet](https://img.shields.io/nuget/v/StravaApiLib?color=brightgreen)](https://www.nuget.org/packages/StravaApiLib)

A lightweight .NET wrapper for the Strava API v3.

This library simplifies working with the Strava API by handling:
- OAuth token refresh automatically
- Secure API authentication
- Typed DTO models
- Clean and minimal API surface



## 🚀 Features

- Automatic access token refresh (uses refresh token internally)
- Strongly typed DTOs
- Simple async API methods
- Minimal setup required after OAuth


## 📦 Supported Endpoints

- Athlete profile
- Athlete statistics
- Activities (paginated)
- Activity details
- Gear details

More endpoints may be added in future updates.



## 🔐 Authentication Overview

Strava uses OAuth2 authentication.

There are **two ways to use this library**:



### Option 1: Using a Refresh Token

Once you have a refresh token, you can use the API directly:

```csharp
var api = new StravaApi(clientId, clientSecret, refreshToken, 30);
```

### Option 2: Full OAuth Flow (First-time setup only)

Use this if you do NOT yet have a refresh token.

1. Generate authorization URL
```csharp
var url = StravaApi.GetAuthorizationUrl(clientId, redirectUri);
```

Open this URL in a browser and let the user log in.

After approval, Strava will redirect to:
https://your-redirect-uri?code=AUTH_CODE

2. Exchange code for tokens
```csharp
var (accessToken, refreshToken) = await StravaApi.ExchangeCodeAsync(clientId, clientSecret, codeFromRedirect);
```

👉 Save the refreshToken — this is what you use long-term. The accessToken is short-lived and used internally by Strava for API requests.
It is returned for completeness, but it is not required for using this library, since the library automatically manages token refresh internally.

```csharp
🏁 Example Usage
var api = new StravaApi(clientId, clientSecret, refreshToken, 30);

// Athlete
var athlete = await api.GetAthleteAsync();

// Activities
var activities = await api.GetActivitiesAsync(page: 1, perPage: 30);

// Activity details
var activity = await api.GetActivityDetailsAsync(activityId);

// Stats
var stats = await api.GetAthleteStatsAsync(athlete.Id);

// Gear
var gear = await api.GetGearAsync(athlete.Shoes.First().Id);
```

## Installation

Install via NuGet:

```bash
dotnet add package StravaApiLib
```

## ⚠️ Notes
Access tokens are handled automatically internally
Refresh tokens must be securely stored by the consumer
Authorization codes are single-use and expire quickly
Redirect URI must match your Strava app settings exactly
