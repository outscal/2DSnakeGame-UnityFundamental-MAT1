using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Consumable
{
    public abstract class Consumable : MonoBehaviour
    {
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out SnakeController snake))
			{
				Consume(snake);
				Repostion();
			}
			
		}

		private void Repostion()
		{
			transform.position = new Vector3(Random.Range(35, -35), Random.Range(-19, 19), 0);
		}

		public abstract void Consume(SnakeController snake);	
	}
}
