# StravaApiLib

[![NuGet](https://img.shields.io/nuget/v/StravaApiLib?color=brightgreen)](https://www.nuget.org/packages/StravaApiLib)

A lightweight .NET wrapper for the Strava API v3.

This library simplifies working with the Strava API by handling:
- OAuth token refresh automatically
- Secure API authentication
- Typed DTO models
- Clean and minimal API surface

---

## 🚀 Features

- Automatic access token refresh (uses refresh token internally)
- Strongly typed DTOs
- Simple async API methods
- Minimal setup required after OAuth

---

## 📦 Supported Endpoints

- Athlete profile
- Athlete statistics
- Activities (paginated)
- Activity details
- Gear details

More endpoints may be added in future updates.

---

## 🔐 Authentication Overview

Strava uses OAuth2 authentication.

There are **two ways to use this library**:

---

### ✅ Option 1: Using a Refresh Token (Recommended)

Once you have a refresh token, you can use the API directly:

```csharp
var api = new StravaApi(clientId, clientSecret, refreshToken, 30);

var athlete = await api.GetAthleteAsync();
var activities = await api.GetActivitiesAsync();
var stats = await api.GetAthleteStatsAsync(athlete.Id);
