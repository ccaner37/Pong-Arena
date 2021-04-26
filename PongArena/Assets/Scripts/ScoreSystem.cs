using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
	public float p1Score = 0;
	float p2Score = 0;

	public GameObject p1ScoreText;
	public GameObject p2ScoreText;

	public float finalScore;

    // Update is called once per frame
    void Update()
    {
		if (p1Score >= finalScore || p2Score >= finalScore)
		{
			Debug.Log("Game Finished");
			SceneManager.LoadScene("GameOver");
		}
    }

	private void FixedUpdate()
	{
		Text uiScoreP1 = p1ScoreText.GetComponent<Text>();
		uiScoreP1.text = p1Score.ToString();

		Text uiScoreP2 = p2ScoreText.GetComponent<Text>();
		uiScoreP2.text = p2Score.ToString();
	}

	public void p1Goal()
	{
		p1Score += 1;
	}

	public void p1Skill()
	{
		p1Score -= 0.5f;
	}

	public void p2Goal()
	{
		p2Score += 1;
	}

}
