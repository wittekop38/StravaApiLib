# StravaApiLib

[![NuGet](https://img.shields.io/nuget/v/StravaApiLib?color=brightgreen)](https://www.nuget.org/packages/StravaApiLib)

A lightweight .NET wrapper for the Strava API.

This library simplifies working with the Strava API by handling:
- OAuth token refresh
- Authentication
- Typed DTOs
- Clean, minimal API calls

---
## Supported Endpoints
- Get athlete
- Get athlete stats
- Get activities
- Get activity details

More endpoints may be added in the future.

---

## Usage
```
var api = new StravaApi(clientId, clientSecret, refreshToken, 30);

// Get athlete
var athlete = await api.GetAthleteAsync();

// Get activities
var activities = await api.GetActivitiesAsync();

// Get activity details
var activity = await api.GetActivityDetailsAsync(activityId);

// Get stats
var stats = await api.GetAthleteStatsAsync(athlete.Id);
```

## 🚀 Installation

Install via NuGet:

```bash
dotnet add package StravaApiLib
