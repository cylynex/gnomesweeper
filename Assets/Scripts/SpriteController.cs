﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

    public Sprite defaultSprite;
    public Sprite mineSprite;
    public Sprite securedTileSprite;
    public Sprite deadlyMineSprite;
    public Sprite securedMineSprite;
    public Sprite[] emptyTileSprites;
    Minefield minefield;

    void Start() {
        //topbar = GameObject.FindGameObjectWithTag("topbar").GetComponent<TopBar>();
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
    }


    public void SetEmptyTileSprite(int amountNeighborMines) {
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[amountNeighborMines];
        GetComponent<BoxCollider2D>().enabled = false;
    }


    // Set Mine
    public void SetMineSprite() {
        GetComponent<SpriteRenderer>().sprite = mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("mine");
    }


    // Set secured tile
    public void SetSecuredTileSprite() {
        GetComponent<SpriteRenderer>().sprite = securedTileSprite;
        minefield.SubtractMine();
    }


    // Set Deadly Mineww
    public void SetDeadlyMineSprite() {
        GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("deadly");
    }


    // Set secured mine
    public void SetSecuredMineSprite() {
        GetComponent<SpriteRenderer>().sprite = securedMineSprite;
        Debug.Log("secured");
    }


    // Set default tile
    public void SetDefaultSprite() {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        minefield.AddMine();
    }



}
