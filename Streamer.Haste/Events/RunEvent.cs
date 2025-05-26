using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Streamer.Haste.Events
{
    internal abstract class RunEvent : StreamerBotEvent
    {
        public abstract string GetEventType();
        public virtual Dictionary<string, string> GetEventData()
        {
            if (RunHandler.InRun)
                return new()
                {
                    { "inRun", RunHandler.InRun.ToString() },
                    { "isEndless", RunHandler.config.isEndless.ToString() },
                    { "isKeepRunning", RunHandler.RunData.isKeepRunningMode.ToString() },
                    { "shardId", RunHandler.RunData.shardID.ToString() },
                    { "seed", RunHandler.RunData.currentSeed.ToString() },
                    { "queuedNodeCount", RunHandler.RunData.QueuedNodes.Count.ToString() },
                    { "runTitle", RunHandler.RunData.runConfig.title },
                    { "lives", RunHandler.RunData.playerData.lives.ToString() },
                    { "maxLives", DisplayStatCorrectly(Player.localPlayer.stats.lives).ToString() },
                    { "currentLevel", RunHandler.RunData.currentLevel.ToString() },
                    { "currentLevelType", RunHandler.RunData.currentNode.type.ToString() },
                    { "currentHealth", Player.localPlayer.data.currentHealth.ToString() },
                    { "maxHealth", DisplayStatCorrectly(Player.localPlayer.stats.maxHealth).ToString() },
                    { "currentEnergy", Player.localPlayer.data.energy.ToString() },
                    { "maxEnergy", DisplayStatCorrectly(Player.localPlayer.stats.maxEnergy).ToString() }
                };
            else
                return new()
                {
                    { "inRun", RunHandler.InRun.ToString() },
                    { "maxLives", DisplayStatCorrectly(Player.localPlayer.stats.lives).ToString() },
                    { "maxHealth", DisplayStatCorrectly(Player.localPlayer.stats.maxHealth).ToString() },
                    { "maxEnergy", DisplayStatCorrectly(Player.localPlayer.stats.maxEnergy).ToString() }
                };
        }

        private static int DisplayStatCorrectly(PlayerStat stat)
        {
            if (stat.baseValue == 0)
                return 0;
            else
                return Mathf.RoundToInt(stat.baseValue * stat.multiplier);
        }
    }


}
