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

		private List<BodyController> m_Bodies;
		private List<BodyController> m_DeadBodies;
		private SnakeController head;

		// Initialization
		internal void ResetBody()
		{
			if (m_Bodies == null)
				m_Bodies = new List<BodyController>();

			if (m_DeadBodies == null)
				m_DeadBodies = new List<BodyController>();
	
			m_Bodies.Clear();
			for (int i = 0; i < startCount; i++)
			{
				AddBody();
			}
		}

		//Setter
		internal void SetHead(SnakeController snakeController) =>	head = snakeController;

		
		// Movement
		internal void Move(Vector3 position)
		{
			if(IsBodyEmpty())
				return;

			for (int bodyIndex = m_Bodies.Count-1; bodyIndex >= 1; bodyIndex--)
			{
				m_Bodies[bodyIndex].SetPosition(m_Bodies[bodyIndex - 1].transform.position);
			}

			m_Bodies[0].SetPosition(position);
		}
		public bool IsBodyEmpty()
		{
			return m_Bodies.Count == 0 || m_Bodies == null ;
		}

		// Creation
		public void CreateBody()
		{
			BodyController newBody = Object.Instantiate(bodyPrefab);
			newBody.transform.parent = bodyCollection;
			m_Bodies.Add(newBody);
			SetPosition();
		}

		private void SetPosition()
		{
			Vector3 newPosition;
			if (m_Bodies.Count > 1)
				newPosition = m_Bodies[^2].transform.position;
			else
				newPosition = head.transform.position;

			m_Bodies[^1].SetPosition(newPosition);
		}

		// Consume Effect
		internal void AddBody()
		{
			if (m_DeadBodies.Count == 0)
			{
				CreateBody();
				return;
			}

			BodyController body = m_DeadBodies[^1];
			body.SetPosition(m_Bodies[^1].transform.position);
			m_Bodies.Add(body);
			m_DeadBodies.Remove(body);
			body.gameObject.SetActive(true);
		}

		internal void RemoveBody()
		{
			if(m_Bodies.Count == 0)
			{
				head.Death();
				return;
			}

			BodyController body = m_Bodies[^1];
			m_DeadBodies.Add(body);
			m_Bodies.Remove(body);
			body.gameObject.SetActive(false);

		}
	}
}