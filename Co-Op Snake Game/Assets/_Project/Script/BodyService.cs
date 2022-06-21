using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Snake
{
	[System.Serializable]
	public class BodyService
	{
		public BodyController bodyPrefab;
		public Transform bodyCollection;
		public int startCount;

		private List<BodyController> m_bodies;
		private SnakeController head;

		internal void SetHead(SnakeController snakeController)
		{
			head = snakeController;
		}

		internal void Move(Vector3 position)
		{
			if(IsBodyEmpty())
				return;

			for (int bodyIndex = m_bodies.Count-1; bodyIndex >= 1; bodyIndex--)
			{
				m_bodies[bodyIndex].setPosition(m_bodies[bodyIndex - 1].transform.position);
			}

			m_bodies[0].setPosition(position);
		}

		internal void ResetBody()
		{
			if (m_bodies == null)
				m_bodies = new List<BodyController>();
	
			m_bodies.Clear();
			for (int i = 0; i < startCount; i++)
			{
				CreateBody();
			}
		}

		public void CreateBody()
		{
			BodyController newBody = Object.Instantiate(bodyPrefab);
			newBody.transform.parent = bodyCollection;
			m_bodies.Add(newBody);
			SetPosition();
		}

		private void SetPosition()
		{
			Vector3 newPosition;
			if (m_bodies.Count > 1)
				newPosition = m_bodies[^2].transform.position;
			else
				newPosition = head.transform.position;

			m_bodies[^1].setPosition(newPosition);
		}

		public bool IsBodyEmpty()
		{
			return m_bodies.Count == 0 || m_bodies == null ;
		}
	}
}