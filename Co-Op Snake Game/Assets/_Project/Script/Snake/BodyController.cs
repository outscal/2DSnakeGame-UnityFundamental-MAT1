using System;
using UnityEngine;

namespace SnakeGame.Snake
{
	public class BodyController : MonoBehaviour
	{
		public Color bodyColor;

		internal void setPosition(Vector3 position)
		{
			transform.position = position;
		}
	}
}