using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AI : MonoBehaviour
{
	public float movementSpeed;
	public GameObject ball;


	public Player2 plyscript;
	public Player2AI aiscript;

	public MainMenu mainmenu;

	private void Start()
	{
		plyscript = GetComponent<Player2>();
		aiscript = GetComponent<Player2AI>();
		mainmenu = GetComponent<MainMenu>();

		if (!MainMenu.playerversusbot)
		{
			plyscript.enabled = true;
			aiscript.enabled = false;
		}
	}

	private void FixedUpdate()
	{
		if (Mathf.Abs(this.transform.position.y - ball.transform.position.y) > 0.25f)
		{
			if(transform.position.y < ball.transform.position.y)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
			}
			else
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
			}
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}
	}
}
