using SnakeGame.Snake;

namespace SnakeGame.Item
{
    public abstract class Consumable : ItemController
    {
		public abstract void Consume(SnakeController snake);
		protected override void CollisionEffect(SnakeController snake)
		{
			Consume(snake);
			base.CollisionEffect(snake);
		}
	}
}
