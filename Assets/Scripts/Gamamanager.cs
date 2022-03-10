using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Gamamanager : MonoBehaviour {

	public Text timetext;
	public Text besttext;
	public GameObject menupanel;
	public Text GameOver;
	public Text lookup;

	public bool pause = false;
	Player playerinstance;
	float timer;
	float besttime;
	bool saved;
	bool flag;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		menupanel.SetActive(false);
		playerinstance = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		timer = 0;
		besttime = PlayerPrefs.GetFloat ("Best Score", 0);
		besttime *= 10;
		int temptime = (int)besttime;
		besttime = temptime;
		besttime /= 10;
		besttext.text = besttime.ToString ();
		saved = false;
		flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((timer) > 5&&(flag == false)) {
			lookup.CrossFadeColor (Color.clear, 5, false, true);
			flag = true;
		}
				
		if ((timer) > 10&&(flag == true)) {
			lookup.enabled = false;
			flag = false;
		}


		if (Input.GetKeyDown (KeyCode.Escape)) {
			pausetoggle ();
		}
		if((pause==false)&&(playerinstance.live)&&(playerinstance.ejected==false))
		{
			timer += Time.deltaTime;
			float timertemp = timer;
			timertemp *= 10;
			int tempint = (int)timertemp;
			timertemp = tempint;
			timertemp /= 10;
			timetext.text = timertemp.ToString ();
		}

		if(((playerinstance.live==false)||(playerinstance.ejected))&&(saved==false))
		{
			saved = true;
			if(besttime<timer)
			{
				besttime=timer;
				PlayerPrefs.SetFloat("Best Score",besttime);
			}

			if (playerinstance.ejected) {
				GameOver.text = "EJECTED";
			} else {
				if (playerinstance.melted) {
					GameOver.text = "MELTED";
				} else {
					GameOver.text = "SMASHED";
				}
			}
		}
	}

	public void pausetoggle()
	{
		if (pause) {
			pause = false;
			Time.timeScale = 1;
			menupanel.SetActive(false);
		} else {
			Time.timeScale = 0;
			pause = true;
			menupanel.SetActive (true);
		}
	}

	public void restattlevel()
	{
		SceneManager.LoadScene ("Level");
	}
	public void exitgame()
	{
		Application.Quit ();
	}
}
