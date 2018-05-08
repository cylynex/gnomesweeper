using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

    public Sprite defaultSprite;
    public Sprite mineSprite;
    public Sprite securedTileSprite;
    public Sprite deadlyMineSprite;
    public Sprite securedMineSprite;
    public Sprite[] emptyTileSprites;





    public void SetEmptyTileSprite(int amountNeighborMines) {
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[amountNeighborMines];
        GetComponent<BoxCollider2D>().enabled = false;
    }


    // Set Mine
    public void SetMineSprite() {
        GetComponent<SpriteRenderer>().sprite = mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }


    // Set secured tile
    public void SetSecuredTileSprite() {
        GetComponent<SpriteRenderer>().sprite = securedTileSprite;
    }


    // Set Deadly Mineww
    public void SetDeadlyMineSprite() {
        GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }


    // Set secured mine
    public void SetSecuredMineSprite() {
        GetComponent<SpriteRenderer>().sprite = securedMineSprite;
    }


    // Set default tile
    public void SetDefaultSprite() {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }



}
