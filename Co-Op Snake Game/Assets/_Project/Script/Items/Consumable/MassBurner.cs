using SnakeGame.Snake;

namespace SnakeGame.Item.Consumbale
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
			GameManager.Instance.UpdateScore(score, snake.team, true);
		}
	}
}
