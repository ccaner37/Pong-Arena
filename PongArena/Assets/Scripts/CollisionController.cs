using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
	public BallMovement ballMovement;
	public ScoreSystem scoreSystem;
	void BounceFromRacket(Collision2D c)
	{
		Vector3 ballPosition = this.transform.position;
		Vector3 racketPosition = c.gameObject.transform.position;

		float racketHeight = c.collider.bounds.size.y;

		float x;

		if (c.gameObject.name == "Player1")
		{
			x = 1;
		}
		else
		{
			x = -1;
		}

		float y = (ballPosition.y - racketPosition.y) / racketHeight;

		this.ballMovement.IncreaseHitCounter();
		this.ballMovement.MoveBall(new Vector2(x,y), true);
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
		{
			BounceFromRacket(collision);
		}
		else if (collision.gameObject.name == "Left")
		{
			scoreSystem.p2Goal();
			StartCoroutine(ballMovement.StartBall(true));
		}
		else if (collision.gameObject.name == "Right")
		{
			scoreSystem.p1Goal();
			StartCoroutine(ballMovement.StartBall(false));
		}
	}

}
