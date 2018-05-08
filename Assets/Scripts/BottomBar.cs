using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBar : MonoBehaviour {

    Minefield minefield;

    void Start() {
        this.minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
    }

    private void FixedUpdate() {
        this.transform.position = new Vector2(0, -((this.minefield.yTotal - 1f) / 2f + 2f));
        RectTransform rectTrans = (RectTransform)this.transform;
        rectTrans.sizeDelta = new Vector2(this.minefield.xTotal + 3, 3);
    }

}
