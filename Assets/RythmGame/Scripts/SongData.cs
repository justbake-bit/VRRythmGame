using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace justbake.RythmGame
{
	[CreateAssetMenu(fileName="Song Data", menuName = "New Song Data")]
	public class SongData : ScriptableObject
	{
		public AudioClip song;
		public int bpm;
		public float startTime;
		public float speed;
	}
}
