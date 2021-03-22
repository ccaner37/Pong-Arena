using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
	public AudioSource hitSoundEffect;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		hitSoundEffect.Play();
	}
}
