using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

	public float movementSpeed;
	public float speedIncreasement;
	public float maxSpeed;

	float hitCounter = 0;

    void Start()
    {
		StartCoroutine(this.StartBall()); 
    }


	void PositionBall(bool isStartingPlayer1)
	{
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

		if (isStartingPlayer1)
		{
			this.gameObject.transform.localPosition = new Vector3(-0.48f,-0.67f,0);
		}
		else
		{
			this.gameObject.transform.localPosition = new Vector3(1, -0.67f, 0);
		}
	}

	public IEnumerator StartBall(bool isStartingPlayer1 = true)
	{
		PositionBall(isStartingPlayer1);

		this.hitCounter = 0;
		yield return new WaitForSeconds(2);
		if (isStartingPlayer1) {
			this.MoveBall(new Vector2(-1, 0), false); }
		else {
			this.MoveBall(new Vector2(1, 0), false);  }
	}

	public void MoveBall(Vector2 dir, bool after)
	{
		dir = dir.normalized;

		float speed = this.movementSpeed + this.hitCounter * this.speedIncreasement;

		Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();

		if (after) { speed = speed * 0.20f; }

		rigidbody.velocity = dir * speed * Time.deltaTime;
	}

	public void IncreaseHitCounter()
	{
		if(this.hitCounter * this.speedIncreasement <= this.maxSpeed)
		{
			hitCounter++;
		}
	}

}
