using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minefield : MonoBehaviour {

    public int amountMines;
    public int amountTilesUnrevealed;
    public bool gameStarted = false;

    public int xTotal;
    public int yTotal;
    public Tile[,] tiles;

    TopBar topbar;

    void Start() {
        topbar = GameObject.FindGameObjectWithTag("topbar").GetComponent<TopBar>();
    }

    public void CreateMineField(int xTotal, int yTotal, int amountMines, int timeLeft) {
        
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.amountMines = amountMines;
        this.amountTilesUnrevealed = xTotal * yTotal;
        this.gameStarted = false;

        // Timer Stuff
        topbar.timerDisplay.text = timeLeft.ToString();
        topbar.timer = timeLeft;

        // Set amount of mines
        topbar.mineCounter.text = amountMines.ToString();

        // Delete all existing tiles
        if (this.tiles != null) {
            foreach(Tile tile in this.tiles) {
                Destroy(tile.gameObject);
            }
        }

        this.tiles = new Tile[xTotal, yTotal];

        for (int x = 0; x < xTotal; x++) {
            for (int y = 0; y < yTotal; y++) {
                tiles[x, y] = Tile.CreateNewTile(x, y);
            }
        }

    }


    public void CreateGame(int level) {
        switch (level) {
            case 1:
                CreateMineField(10, 10, 10,100);
                break;
            case 2:
                CreateMineField(20, 20, 20,250);
                break;
            case 3:
                CreateMineField(30, 30, 30,500);
                break;
        }
    }


    public bool IsGameWon() {
        if (amountTilesUnrevealed == amountMines) {
            return true;
        } else {
            return false;
        }
    }


    public void LoseGame() {
        Debug.Log("lose");
    }


    public void WinGame() {
        Debug.Log("win");
    }

}
