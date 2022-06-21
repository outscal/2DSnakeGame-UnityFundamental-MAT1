using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Consumable
{
    public class MassBurner : Consumable
    {
        public int BurnAmount;

		public override void Consume(SnakeController snake)
		{
			for (int i = 0; i < BurnAmount; i++)
			{
				snake.bodyService.RemoveBody();
			}
		}
	}
}
