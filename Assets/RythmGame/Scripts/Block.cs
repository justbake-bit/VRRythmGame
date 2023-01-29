using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace justbake.RythmGame
{
	public enum BlockColor {
		RED,
		GREEN
	}
	
	public class Block : MonoBehaviour
	{
		
		public BlockColor color;
		
		public GameObject brokenBlockLeft;
		public GameObject brokenBlockRight;
		
		public float brokenBlockForce;
		public float brokenBlockTorque;
		public float brokenBlockDestroyDelay;
		
		// OnTriggerEnter is called when the Collider other enters the trigger.
		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("SwordB")) {
				if(color == BlockColor.RED && GameManager.instance.rightSwordTrakcer.velocity.magnitude >= GameManager.instance.swordHitVelocityThreshold){
					// add to player score
					GameManager.instance.AddScore();
				}
				else 
				{
					GameManager.instance.HitWrongBlock();
				}
				Hit();
			}
			else if(other.CompareTag("SwordA")) {
				if(color == BlockColor.GREEN && GameManager.instance.leftSwordTrakcer.velocity.magnitude >= GameManager.instance.swordHitVelocityThreshold){
					// add to player score
					GameManager.instance.AddScore();
				}
				else 
				{
					GameManager.instance.HitWrongBlock();
				}
				Hit();
			}
		}
		
		public void Hit()
		{
			// enable broken pieces
			brokenBlockLeft.SetActive(true);
			brokenBlockRight.SetActive(true);
			
			// remove them as children
			brokenBlockLeft.transform.parent = null;
			brokenBlockRight.transform.parent = null;
			
			// get their rigidbodies
			Rigidbody leftRB = brokenBlockLeft.GetComponent<Rigidbody>();
			Rigidbody rightRB = brokenBlockRight.GetComponent<Rigidbody>();
			
			// add force to them
			leftRB.AddForce(-transform.right * brokenBlockForce, ForceMode.Impulse);
			rightRB.AddForce(transform.right * brokenBlockForce, ForceMode.Impulse);
			
			// add torque to them
			leftRB.AddTorque(-transform.forward * brokenBlockTorque, ForceMode.Impulse);
			rightRB.AddTorque(transform.forward * brokenBlockTorque, ForceMode.Impulse);
			
			// destroy broken pieces after a few seconds
			Destroy(brokenBlockLeft, brokenBlockDestroyDelay);
			Destroy(brokenBlockRight, brokenBlockDestroyDelay);
			
			// destroy main block
			Destroy(gameObject);
		}
	}
}
