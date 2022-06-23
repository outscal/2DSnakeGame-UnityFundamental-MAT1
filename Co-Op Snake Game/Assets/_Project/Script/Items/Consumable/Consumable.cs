using SnakeGame.Snake;

namespace SnakeGame.Item.Consumbale
{
    public abstract class Consumable : ItemController
    {
		public int score;
		public abstract void Consume(SnakeController snake);
		protected override void CollisionEffect(SnakeController snake)
		{
			base.CollisionEffect(snake);
			Consume(snake);
		}
	}
}
