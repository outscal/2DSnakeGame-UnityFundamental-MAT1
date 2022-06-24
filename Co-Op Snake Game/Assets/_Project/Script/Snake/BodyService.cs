using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Snake
{
	[System.Serializable]
	public class BodyService
	{
		public BodyController bodyPrefab;
		public Transform BodyCollection { get; set; }
		public int StartCount { get; set; }

		private List<BodyController> m_Bodies;
		private List<BodyController> m_DeadBodies;
		private SnakeController head;

		// Initialization
		public void ResetBody()
		{
			if (m_Bodies == null)
				m_Bodies = new List<BodyController>();

			if (m_DeadBodies == null)
				m_DeadBodies = new List<BodyController>();
	
			m_Bodies.Clear();
			for (int i = 0; i < StartCount; i++)
			{
				AddBody();
			}
		}

		//Setter
		public void SetHead(SnakeController snakeController) =>	head = snakeController;

		
		// Movement
		public void Move(Vector3 position)
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
			newBody.transform.parent = BodyCollection;
			newBody.GetComponent<SpriteRenderer>().color = head.Color;
			newBody.team = head.team;
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
		public void AddBody()
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

		public void RemoveBody()
		{
			if(m_Bodies.Count == 0)
			{
				head.Death(true);
				return;
			}

			BodyController body = m_Bodies[^1];
			m_DeadBodies.Add(body);
			m_Bodies.Remove(body);
			body.gameObject.SetActive(false);

		}
	}
}