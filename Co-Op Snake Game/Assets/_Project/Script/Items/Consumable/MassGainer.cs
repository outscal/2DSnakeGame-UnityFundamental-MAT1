using SnakeGame.Snake;
using SnakeGame.Item.PowerUp;

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

			int effectiveScore = score;

			if (snake.activePower != null)
				if (snake.activePower.TryGetComponent(out ScoreBoost scoreBoost))
					effectiveScore *= scoreBoost.boostMultiplier;
		
			GameManager.Instance.UpdateScore(effectiveScore, snake.team);
		}
	}
}
