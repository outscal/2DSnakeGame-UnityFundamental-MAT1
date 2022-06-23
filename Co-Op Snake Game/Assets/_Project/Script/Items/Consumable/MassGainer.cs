using SnakeGame.Snake;

namespace SnakeGame.Item.Consumbale
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
