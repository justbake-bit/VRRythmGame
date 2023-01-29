using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace justbake.RythmGame
{
	public class MissHitDetector : MonoBehaviour
	{
		// OnTriggerEnter is called when the Collider other enters the trigger.
		protected void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("Block"))
			{
				other.GetComponent<Block>().Hit();
				GameManager.instance.MissBlock();
			}
		}
	}
}
