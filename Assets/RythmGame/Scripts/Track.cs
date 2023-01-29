using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace justbake.RythmGame
{
	public class Track : MonoBehaviour
	{
		public SongData song;
		public AudioSource audioSource;
		
		private void StartSong()
		{
			audioSource.PlayOneShot(song.song);
			Invoke("SongIsOver", song.song.length);
		}
		
		private void SongIsOver()
		{
			GameManager.instance.WinGame();
		}
		
		// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
		protected void Start()
		{
			transform.position = Vector3.forward * (GameManager.instance.startDelay * song.speed);
			Invoke("StartSong", GameManager.instance.startDelay - song.startTime);
		}
		
		// Update is called every frame, if the MonoBehaviour is enabled.
		protected void Update()
		{
			transform.position += Vector3.back * song.speed * Time.deltaTime;
		}
		
		// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
		protected void OnDrawGizmos()
		{
			float beatLength = 60.0f / (float) song.bpm;
			float beatDist = beatLength * song.speed;
			for (int i = 0; i < 100; i++)
			{
				Gizmos.DrawLine(transform.position + new Vector3(-1, 0, i*beatDist), transform.position + new Vector3(1, 0, i*beatDist));
			}
		}
	}
}
