using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrickSystem : MonoBehaviour
{

	public Collider2D[] walls;
	public SpriteRenderer[] wallssprite;
	private bool inCooldown = false;
	public ScoreSystem scoreSystem;
	public Text skillText;

	// Start is called before the first frame update
	void Start()
    {
		foreach (Collider2D wall in walls)
		{
			wall.enabled = false;
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("q") && !inCooldown && scoreSystem.p1Score >= 0.5f)
		{
			scoreSystem.p1Skill();
			EnableMiddleWalls();
		}
    }

	private void EnableMiddleWalls()
	{
		foreach (Collider2D wall in walls)
		{
			wall.enabled = true;
			inCooldown = true;
		}
		foreach (SpriteRenderer walltrans in wallssprite)
		{
			walltrans.color = new Color(1, 1, 1, 1);
		}
		skillText.enabled = false;
		StartCoroutine(StartCooldown());
		StartCoroutine(DisableMiddleWalls());
	}

	private IEnumerator StartCooldown()
	{
		yield return new WaitForSeconds(15);
		inCooldown = false;
		skillText.enabled = true;
	}

	private IEnumerator DisableMiddleWalls()
	{
		yield return new WaitForSeconds(5);
		foreach (Collider2D wall in walls)
		{
			wall.enabled = false;
			Debug.Log("Walls Disabled");
		}
		foreach (SpriteRenderer walltrans in wallssprite)
		{
			walltrans.color = new Color(1, 1, 1, 0.49f);
		}
	}


}
