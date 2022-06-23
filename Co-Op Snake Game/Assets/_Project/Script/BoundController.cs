using UnityEngine;

namespace SnakeGame
{
    public struct Boundary
	{
        public int boundMinX;
        public int boundMaxX;
		public int boundMinY;
		public int boundMaxY;
	}

    public class BoundController : MonoBehaviour
    {
        public static Boundary bounds;

		private BoxCollider2D col; 

		private void Awake()
		{
			bounds = new Boundary();
			col = GetComponent<BoxCollider2D>();
			IntializeBounds();
		}

		private void IntializeBounds()
		{
			bounds.boundMaxX = (int)(col.size.x/2); 
			bounds.boundMinX = - bounds.boundMaxX;
			bounds.boundMaxY = (int)(col.size.y/2);
			bounds.boundMinY = - bounds.boundMaxY;
		}

		public static Vector2 Repostion()
		{
			return new Vector2(
				Random.Range(bounds.boundMinX, bounds.boundMaxX),
				Random.Range(bounds.boundMinY, bounds.boundMaxY));
		}
	}
}
