# Streamer.Haste

Automated integration of [Haste](https://store.steampowered.com/app/1796470/HASTE_Broken_Worlds/) and [Streamer.bot](https://streamer.bot/) to allow Haste to trigger Actions in Streamer.bot.

This allows Haste to cause things to happen on stream, for example: automatically updating a !seed command, a text overlay with the progress of the shard, or a silly message in chat when you die.

## Installation

1) [Install](https://docs.streamer.bot/get-started/installation) and [Setup](https://docs.streamer.bot/get-started/setup) Streamer.bot.
2) Make sure the [Http Server](https://docs.streamer.bot/api/servers/http) is enabled in Streamer.bot.
2) Subscribe to this mod on the Steam Workshop.
3) Import the [pre-made Actions](Streamer.Haste.streamerbot) into Streamer.bot
4) (Optional) Customize the Actions to your liking.
5) Use the in-game settings menu to test the events!

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

This event is automatically sent when the continue/new game button is pressed. It can be used to trigger actions that should happen when the game starts, such as updating the game category or title.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `GameLaunch` | The type of event. This will always be `GameLaunch` for this event. |

</details>

### GameExit

EventType: `GameExit`

This event is automatically sent when quitting the game. It can be used to trigger actions that should happen when the game exits, such as updating the game category or title.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `GameExit` | The type of event. This will always be `GameExit` for this event. |

</details>

### RunStart

EventType: `RunStart`

This event is sent when starting a new run. You can use this to access information on the run such as shard number or seed.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `RunStart` | The type of event. This will always be `RunStart` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### RunWin

EventType: `RunWin`

This event is sent when you win a run/shard. Note this will be sent twice for any shard where you pick Keep Running, once on defeating the Boss and once again when you finish Keep Running.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `RunWin` | The type of event. This will always be `RunWin` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Boss` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### RunLose

EventType: `RunLose`

This event is sent when you lose a run/shard. Note: leaving endless mode is *technically* a loss, so don't be surprised. You can use `isEndless` to determine if the run was endless or not.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `RunLose` | The type of event. This will always be `RunLose` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### LevelStart

EventType: `LevelStart`

This event is sent when you start a level/fragment. Note that some things you may not consider "levels" such as shops and rest areas may trigger this event. You can use `currentLevelType` to determine what type of level it is.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `LevelStart` | The type of event. This will always be `LevelStart` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### LevelWin

EventType: `LevelWin`

This event is sent when you win a level/fragment. Note that some things you may not consider "levels" such as shops and rest areas may trigger this event. You can use `currentLevelType` to determine what type of level it is.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `LevelWin` | The type of event. This will always be `LevelWin` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### LevelRestart

EventType: `LevelRestart`

This event is sent whenever the level restarts, usually because of dying.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `LevelRestart` | The type of event. This will always be `LevelRestart` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### Died

EventType: `Died`

This event is sent whenever you die. This can happen either in a level or in the hub world, with different event arguments available depending on if you are in a run.

<details>
<summary>Available Event Arguments</summary>

**When in a run**
| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `Died` | The type of event. This will always be `Died` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

**When _not_ in a run**
| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `Died` | The type of event. This will always be `Died` for this event. |
| inRun | `False` | Whether the player is in a run or not. |
| maxLives | `3` | The maximum number of lives. |
| maxHealth | `100` | The maximum health of the player. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |

</details>

### TutorialStep

EventType: `TutorialStep`

This event is sent during the tutorial.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `TutorialStep` | The type of event. This will always be `TutorialStep` for this event. |
| step | `0` | The current step of the tutorial. |

</details>

### BossDeath

EventType: `BossDeath`

This event is sent when you defeat a Boss. You can use the argument `IsFinalBoss` to determine if this is the final boss of the game or not.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `BossDeath` | The type of event. This will always be `BossDeath` for this event. |
| inRun | `True` | Whether the player is in a run or not. |
| isEndless | `False` | Whether the run is configured to be endless. |
| isKeepRunning | `False` | Whether the run is currently in the Keep Running state post-boss. |
| shardId | `0` | The ID of the shard. Add one to get the shard number for shards 1-10. Endless Shard has a shardId of `100` |
| seed | `1744746608` | The seed of the run. |
| queuedNodeCount | `0` | The number of queued nodes in the current path. |
| runTitle | `Forest 1` | The title of the run. |
| lives | `3` | The number of lives remaining. |
| maxLives | `3` | The maximum number of lives. |
| currentLevel | `0` | The current level of the run. |
| currentLevelType | `Default` | The type of the current level. Values are `Default`, `Shop`, `Challenge`, `Encounter`, `Boss`, and `RestStop` |
| currentHealth | `100` | The current health of the player. |
| maxHealth | `100` | The maximum health of the player. |
| currentEnergy | `0.126` | The current energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| maxEnergy | `1` | The maximum energy of the player. Note as of the first release of this mod it's best used for percentage of energy available. |
| IsFinalBoss | `False` | Whether the boss is the final boss of the game or not. |

</details>

### SpawnedInHub

EventType: `SpawnedInHub`

This event is sent every time you spawn in the main hub world. This includes loading in from the main menu or a run.

<details>
<summary>Available Event Arguments</summary>

| Name | Example | Description |
|------|-------------| ------------------|
| eventType | `SpawnedInHub` | The type of event. This will always be `SpawnedInHub` for this event. |

</details>