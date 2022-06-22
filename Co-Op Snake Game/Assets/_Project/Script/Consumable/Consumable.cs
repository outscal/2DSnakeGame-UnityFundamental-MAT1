using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Consumable
{
    public abstract class Consumable : MonoBehaviour
    {
		private Boundary bounds;

		private void Start()
		{
			bounds = BoundController.bounds;
		}
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
			transform.position = new Vector3(
				Random.Range(bounds.boundMinX, bounds.boundMaxX), 
				Random.Range(bounds.boundMinY, bounds.boundMaxY), 0);
		}

		public abstract void Consume(SnakeController snake);	
	}
}
