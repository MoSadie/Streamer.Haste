# Streamer.Haste

Automated integration of [Haste][https://store.steampowered.com/app/1796470/HASTE_Broken_Worlds/] and [Streamer.bot](https://streamer.bot/) to allow Haste to trigger Actions in Streamer.bot.

This allows Haste to cause things to happen on stream, for example: automatically updating a !seed command, a text overlay with the progress of the shard, or a silly message in chat when you die.

## Installation

1) [Install][https://docs.streamer.bot/get-started/installation] and [Setup](https://docs.streamer.bot/get-started/setup) Streamer.bot.
2) Make sure the [Http Server](https://docs.streamer.bot/api/servers/http) is enabled in Streamer.bot.
2) Subscribe to this mod on the Steam Workshop.
3) Import the pre-made Actions into Streamer.bot
4) (Optional) Customize the Actions to your liking.
5) Update the in-game config to confirm settings are correct.

## Events

### Test

EventType: `Test`

This event is only triggered by the Test Event button in the settings menu. It can be used to make sure the integration is working and that the actions are being triggered correctly.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `Test` | The type of event. This will always be `Test` for this event. |

</details>

### GameLaunch

EventType: `GameLaunch`

This event is automatically sent when the game is launched. It can be used to trigger actions that should happen when the game starts, such as updating the game category or title.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `GameLaunch` | The type of event. This will always be `GameLaunch` for this event. |

</details>