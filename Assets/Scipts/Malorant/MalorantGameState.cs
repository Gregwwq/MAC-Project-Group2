using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Malorant
{
    public class MalorantGameState : MonoBehaviour
    {
        public float timeMin;
        public float timeSec;
        public float timeLeft;
        public bool gameStarted;
        public GameObject loseUI;
        public GameObject winUI;
        public GameObject enemies;
        public Text timerUI;

        // Start is called before the first frame update
        void Start()
        {
            enemies = GameObject.Find("Spawner");
            timeLeft = timeMin * 60 + timeSec;
            gameStarted = false;
        }

        void Update()
        {
            if (gameStarted == true)
            {
                timeLeft -= Time.deltaTime;

                string minutes = ((int)timeLeft / 60).ToString("00");
                string seconds = Mathf.Round(timeLeft % 60).ToString("00");
                timerUI.text = minutes + ":" + seconds;

                if (timeLeft < 0)
                {
                    timeLeft = 0;
                    Time.timeScale = 0;
                    loseUI.SetActive(true);

                }
            }
        }

        public void CheckWin()
        {
            if(enemies.transform.childCount <= 1)
            {
                timeLeft = 0;
                Time.timeScale = 0;
                winUI.SetActive(true);
            }
        }
    }

}