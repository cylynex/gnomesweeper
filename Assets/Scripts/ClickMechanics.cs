﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMechanics : MonoBehaviour {

    Minefield minefield;
    SpriteController spriteController;
    Tile tile;


    void Start() {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        spriteController = GetComponent<SpriteController>();
        tile = GetComponent<Tile>();
    }



    // Right Click
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            if (tile.isSecured) {
                Debug.Log("secured");
                spriteController.SetDefaultSprite();
                tile.isSecured = false;
            } else {
                Debug.Log("not secured");
                spriteController.SetSecuredTileSprite();
                tile.isSecured = true;
            }
        }
    }


    // Left Click
    private void OnMouseUpAsButton() {
        ClickTile();
    }


    // What happens when you click a tile
    void ClickTile() {

        // Setup the game if it hasnt started yet.
        if (!minefield.gameStarted) {

            minefield.gameStarted = true;

            //spriteController.SetDefaultSprite();

            // make mines
            this.CreateMines();
        }

        // Do stuff if game is live
        if (this.tile.isMine) {
            Debug.Log("game over");
        } else {
            this.RevealTile();
        }

    }


    // Add mines to board
    void CreateMines() {
        int minesLeft = minefield.amountMines;
        int tilesLeft = minefield.amountTilesUnrevealed;

        // Loop through tiles and randomly assign mines
        for (int x = 0; x < minefield.xTotal; x++) {
            for (int y = 0; y < minefield.yTotal; y++) {
                Tile thisTile = minefield.tiles[x, y];
                float chanceForMine = (float)minesLeft / (float)tilesLeft;

                if (Random.value <= chanceForMine) {
                    thisTile.isMine = true;
                    minesLeft--;
                }

                tilesLeft--;
            }
        }
    }


    // Reveal single tile if empty
    public void RevealTile() {

        if (!tile.isRevealed && !tile.isMine) {
            // Tile is not revealed and is not a mine
            tile.isRevealed = true;
            minefield.amountTilesUnrevealed--;

            // Set the tile number background sprite
            int amountNeighborMines = this.GetAmountNeighborMines();
            spriteController.SetEmptyTileSprite(amountNeighborMines);

            if (amountNeighborMines == 0) {
                // Reveal tiles around it as well
                RevealIfValid(tile.x - 1, tile.y - 1);
                RevealIfValid(tile.x - 1, tile.y);
                RevealIfValid(tile.x - 1, tile.y + 1);

                RevealIfValid(tile.x, tile.y - 1);
                RevealIfValid(tile.x, tile.y + 1);

                RevealIfValid(tile.x + 1, tile.y - 1);
                RevealIfValid(tile.x + 1, tile.y);
                RevealIfValid(tile.x + 1, tile.y + 1);
            }
        } 
    }


    // Show adjacent tiles which are empty
    void RevealIfValid(int x, int y) {
        Debug.Log("x is " + x + " and y is " + y);
        if (x >= 0 && x <= minefield.xTotal && y >= 0 && y < minefield.yTotal) {
            minefield.tiles[x, y].clickMechanics.RevealTile();
        }
    }


    public int GetAmountNeighborMines() {
        int mineCounter = 0;

        if (hasMine(tile.x - 1, tile.y - 1)) mineCounter++;
        if (hasMine(tile.x - 1, tile.y)) mineCounter++;
        if (hasMine(tile.x - 1, tile.y + 1)) mineCounter++;
        if (hasMine(tile.x, tile.y - 1)) mineCounter++;
        if (hasMine(tile.x, tile.y + 1)) mineCounter++;
        if (hasMine(tile.x + 1, tile.y - 1)) mineCounter++;
        if (hasMine(tile.x + 1, tile.y)) mineCounter++;
        if (hasMine(tile.x + 1, tile.y + 1)) mineCounter++;

        return mineCounter;
    }


    // Check for mine
    bool hasMine(int x, int y) {
        bool mineHere = false;
        if (x >= 0 && x < minefield.xTotal && y >= 0 && y < minefield.yTotal ) {
            mineHere = minefield.tiles[x, y].isMine;
        }

        // Return true or false for if there is a mine here
        return mineHere;
    }




}
