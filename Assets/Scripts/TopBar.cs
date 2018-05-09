using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour {

    Minefield minefield;
    public float timer;
    public Text timerDisplay;
    public Text mineCounter;

    void Start() {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        timer = 0;
    }


    void Update() {

        // Only run the timer if the game is started
        if (minefield.gameStarted) {
            timer -= Time.deltaTime;
            timerDisplay.text = timer.ToString("N0");
            if (timer <= 0) {
                minefield.LoseGame(2);
                minefield.gameStarted = false;
            }
        }
    }

    private void FixedUpdate() {
        this.transform.position = new Vector2(0, ((this.minefield.yTotal - 1f) / 2f + 2f));
        RectTransform rectTrans = (RectTransform)this.transform;
        rectTrans.sizeDelta = new Vector2(this.minefield.xTotal + 3, 3);
    }

}
