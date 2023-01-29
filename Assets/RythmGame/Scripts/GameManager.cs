using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace justbake.RythmGame
{
	public class GameManager : MonoBehaviour
	{
		
		public static GameManager instance;
		
		public float startDelay = 3;
		
		public int score = 0;
		public float lifeTime = 1.0f;

		public int hitBlockScore = 10;
		public float missBlockLife = 0.1f;
		public float wrongBlockLife = 0.08f;
		public float lifeRegenRate = 0.1f;
		
		public float swordHitVelocityThreshold = 0.5f;
		
		public VelocityTracker leftSwordTrakcer;
		public VelocityTracker rightSwordTrakcer;
		
		public void AddScore()
		{
			score += hitBlockScore;
			GameUI.instance.UpdateScoreText();
		}
		
		public void MissBlock()
		{
			lifeTime -= missBlockLife;
		}
		
		public void HitWrongBlock()
		{
			lifeTime -= wrongBlockLife;
		}
		
		// Awake is called when the script instance is being loaded.
		protected void Awake()
		{
			instance = this;
		}
		
		// Update is called every frame, if the MonoBehaviour is enabled.
		protected void Update()
		{
			lifeTime = Mathf.MoveTowards(lifeTime, 1.0f, lifeRegenRate * Time.deltaTime);
			
			if(lifeTime <= 0)
				LooseGame();
			
			GameUI.instance.UpdateLifetimeBar();
		}
		
		public void WinGame()
		{
			SceneManager.LoadScene(0);
		}
		
		public void LooseGame()
		{
			SceneManager.LoadScene(0);
		}
		
	}
}
