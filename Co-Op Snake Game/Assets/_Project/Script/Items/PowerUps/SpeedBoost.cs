using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;
using System;

namespace SnakeGame.Item.PowerUp
{
    public class SpeedBoost : PowerUp
    {
		public float speedMutiplier;
		public override void UsePowerup(SnakeController snake)
		{
			snake.Speed *= speedMutiplier;
		}

		public override void ResetPowerUp(SnakeController snake)
		{
			snake.Speed /= speedMutiplier;
		}
	}
}
