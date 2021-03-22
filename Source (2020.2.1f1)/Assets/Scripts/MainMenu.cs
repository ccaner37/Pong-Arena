using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	static public bool playerversusbot;

	void Start()
    {
		playerversusbot = true;
    }

	public void userToggle(bool tag)
	{
		playerversusbot = tag;
		Debug.Log(playerversusbot);
	}

}
