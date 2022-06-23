using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame.Item
{
    public abstract class ItemController : MonoBehaviour
    {
		protected virtual void Start()
		{
			transform.position = BoundController.Repostion();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out SnakeController snake))
			{
				CollisionEffect(snake);
			}
		}

		protected virtual void CollisionEffect(SnakeController snake)
		{
			transform.position = BoundController.Repostion();
		}
	}
}
