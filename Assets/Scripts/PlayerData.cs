using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public int level;
	public Dictionary<string, string[]> highscore;

	public PlayerData(GameController player)
	{
		level = player.level;
		highscore = player.highscore;
	}
}
