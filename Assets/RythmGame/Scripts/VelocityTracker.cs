using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace justbake.RythmGame
{
	public class VelocityTracker : MonoBehaviour
	{
		public Transform tracker;
		public Vector3 velocity;
		
		private Vector3 lastPosition;
		
		// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
		protected void Start()
		{
			lastPosition = tracker.position;
		}
		
		// Update is called every frame, if the MonoBehaviour is enabled.
		protected void Update()
		{
			velocity = (tracker.position - lastPosition) / Time.deltaTime;
			lastPosition = tracker.position;
		}
	}
}
