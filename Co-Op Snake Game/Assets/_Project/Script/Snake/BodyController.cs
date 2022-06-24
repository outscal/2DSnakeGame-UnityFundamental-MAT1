using System;
using UnityEngine;

namespace SnakeGame.Snake
{
	public class BodyController : MonoBehaviour
	{
		public Color bodyColor;
		public Team team;

		internal void SetPosition(Vector3 position)
		{
			transform.position = position;
		}
	}
}