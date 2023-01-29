using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace justbake.RythmGame
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI instance;
		
		public TextMeshProUGUI scoreText;
		public Image lifeTimeBar;
		
		// Awake is called when the script instance is being loaded.
		protected void Awake()
		{
			instance = this;
		}
		
		public void UpdateScoreText()
		{
			scoreText.text = string.Format("SCORE\n{0}", GameManager.instance.score.ToString());
		}
		
		public void UpdateLifetimeBar()
		{
			lifeTimeBar.fillAmount = GameManager.instance.lifeTime;
		}
	}
}
