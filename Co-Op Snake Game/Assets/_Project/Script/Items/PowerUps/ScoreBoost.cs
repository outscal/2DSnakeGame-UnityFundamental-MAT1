using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Item.PowerUp
{
    public class ScoreBoost : PowerUp
    {
		public int boostMultiplier;
		public override void UsePowerup(SnakeController snake)
		{
			Debug.Log("Score Boost Active");
		}

		public override void ResetPowerUp(SnakeController snake)
		{
			Debug.Log("Score Boost Ended");
		}
	}
}
