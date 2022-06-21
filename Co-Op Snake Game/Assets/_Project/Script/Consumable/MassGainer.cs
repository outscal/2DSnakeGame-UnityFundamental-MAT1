using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Consumable
{
    public class MassGainer : Consumable
    {
        public int GainAmount;

		public override void Consume(SnakeController snake)
		{
			for (int i = 0; i < GainAmount; i++)
			{
				snake.bodyService.AddBody();
			}
		}
	}
}
