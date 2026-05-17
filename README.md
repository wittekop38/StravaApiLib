# StravaApiLib

[![NuGet](https://img.shields.io/nuget/v/StravaApiLib?color=brightgreen)](https://www.nuget.org/packages/StravaApiLib)

A lightweight .NET client for the Strava API v3. Handles OAuth token refresh automatically so you can focus on building.

```bash
dotnet add package StravaApiLib
```

---

## Setup

If you already have a refresh token, you're good to go:

```csharp
var api = new StravaApi(clientId, clientSecret, refreshToken);
```

If you're setting up for the first time, use the built-in OAuth helpers:

```csharp
// 1. Generate the authorization URL and open it in a browser
var url = StravaApi.GetAuthorizationUrl(clientId, redirectUri);

// 2. After the user approves, exchange the code Strava gives you
var (accessToken, refreshToken) = await StravaApi.ExchangeCodeAsync(clientId, clientSecret, code);

// Store the refreshToken — that's what you pass to the constructor going forward.
// The library handles access token refresh automatically from there.
```

---

## Usage

```csharp
var api = new StravaApi(clientId, clientSecret, refreshToken);

// Athlete
var athlete = await api.GetAthleteAsync();
var stats   = await api.GetAthleteStatsAsync(athlete.Id);
var zones   = await api.GetAthleteZonesAsync();
await api.UpdateAthleteAsync(weight: 75.5f);

// Activities
var activities = await api.GetActivitiesAsync(page: 1, perPage: 30);
var detail     = await api.GetActivityDetailsAsync(activityId);
var laps       = await api.GetActivityLapsAsync(activityId);
var comments   = await api.GetActivityCommentsAsync(activityId);
var kudos      = await api.GetActivityKudosAsync(activityId);
var zones      = await api.GetActivityZonesAsync(activityId);

await api.CreateActivityAsync("Morning Run", "Run", DateTime.Now, elapsedTimeSeconds: 3600);
await api.UpdateActivityAsync(activityId, new UpdateActivityRequestDto { Name = "Evening Ride" });

// Segments
var segment = await api.GetSegmentAsync(segmentId);
var starred = await api.GetStarredSegmentsAsync();
var results = await api.ExploreSegmentsAsync("51.5,-0.1,51.6,0.1", activityType: "riding");
await api.StarSegmentAsync(segmentId, starred: true);

// Segment efforts
var efforts = await api.GetSegmentEffortsAsync(segmentId);
var effort  = await api.GetSegmentEffortAsync(effortId);

// Streams
var streams = await api.GetActivityStreamsAsync(activityId, StreamKeys.Time, StreamKeys.Heartrate, StreamKeys.Watts);
double[] hrData = streams.Heartrate?.Data.Select(v => (double)v).ToArray();

// Clubs
var clubs    = await api.GetAthleteClubsAsync();
var members  = await api.GetClubMembersAsync(clubId);

// Routes
var route = await api.GetRouteAsync(routeId);
var gpx   = await api.GetRouteAsGpxAsync(routeId); // returns byte[]

// Gear
var gear = await api.GetGearAsync(gearId);

// Uploads
var upload = await api.CreateUploadAsync(fileStream, "activity.fit", "fit");
var status = await api.GetUploadAsync(upload.Id); // poll until status.ActivityId != null
```

---

## Endpoints

Covers the full Strava API v3 reference:

| Resource | Methods |
|---|---|
| Athletes | `GetAthleteAsync`, `UpdateAthleteAsync`, `GetAthleteStatsAsync`, `GetAthleteZonesAsync` |
| Activities | `GetActivitiesAsync`, `GetActivityDetailsAsync`, `CreateActivityAsync`, `UpdateActivityAsync`, `GetActivityLapsAsync`, `GetActivityCommentsAsync`, `GetActivityKudosAsync`, `GetActivityZonesAsync` |
| Segments | `GetSegmentAsync`, `GetStarredSegmentsAsync`, `StarSegmentAsync`, `ExploreSegmentsAsync` |
| Segment Efforts | `GetSegmentEffortsAsync`, `GetSegmentEffortAsync` |
| Streams | `GetActivityStreamsAsync`, `GetRouteStreamsAsync`, `GetSegmentEffortStreamsAsync`, `GetSegmentStreamsAsync` |
| Clubs | `GetClubAsync`, `GetAthleteClubsAsync`, `GetClubActivitiesAsync`, `GetClubMembersAsync`, `GetClubAdminsAsync` |
| Routes | `GetRouteAsync`, `GetRoutesByAthleteIdAsync`, `GetRouteAsGpxAsync`, `GetRouteAsTcxAsync` |
| Gear | `GetGearAsync` |
| Uploads | `CreateUploadAsync`, `GetUploadAsync` |

---

## Real-world example

[StrideVault](https://github.com/wittekop38/StrideVault) is a personal project built on top of this library — good reference if you want to see it wired up end-to-end.

---

## Notes

- Refresh tokens must be stored securely by the consuming app — the library doesn't persist anything
- Authorization codes are single-use and short-lived
- The redirect URI must exactly match what's registered in your Strava app settings
