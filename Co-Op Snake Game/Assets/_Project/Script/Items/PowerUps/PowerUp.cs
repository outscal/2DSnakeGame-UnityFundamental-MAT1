using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Item.PowerUp
{
    public abstract class PowerUp : ItemController
    {
		public float usagePeriod;
		private SpriteRenderer sprite;
		private PolygonCollider2D col;

		protected override void Start()
		{
			base.Start();
			sprite = GetComponent<SpriteRenderer>();
			col = GetComponent<PolygonCollider2D>();
		}

		protected override void CollisionEffect(SnakeController snake)
		{
			if (snake.activePower == null)
			{
				snake.activePower = this;
				StartCoroutine(WaitPeroid(snake));
			}
			else
				base.CollisionEffect(snake);
		}
		IEnumerator WaitPeroid(SnakeController snake)
		{
			EnableVisuals(false);
			UsePowerup(snake);

			yield return new WaitForSeconds(usagePeriod);

			ResetPowerUp(snake);	
			snake.activePower = null;
			base.CollisionEffect(snake);
			EnableVisuals(true);
		}

		private void EnableVisuals(bool isEnable)
		{
			sprite.enabled = isEnable;
			col.enabled = isEnable;
		}

		public abstract void ResetPowerUp(SnakeController snake);
		public abstract void UsePowerup(SnakeController snake);
	}
}
