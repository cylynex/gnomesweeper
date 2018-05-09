using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minefield : MonoBehaviour {

    public int amountMines;
    public int amountTilesUnrevealed;
    public bool gameStarted = false;
    public int minesLeft;
    public GameObject losePanel;

    public int xTotal;
    public int yTotal;
    public Tile[,] tiles;

    TopBar topbar;

    void Start() {
        topbar = GameObject.FindGameObjectWithTag("topbar").GetComponent<TopBar>();
        losePanel.SetActive(false);
    }

    public void CreateMineField(int xTotal, int yTotal, int amountMines, int timeLeft) {
        
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.amountMines = amountMines;
        this.amountTilesUnrevealed = xTotal * yTotal;
        this.gameStarted = false;
        minesLeft = amountMines;

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
                CreateMineField(20, 20, 40,250);
                break;
            case 3:
                CreateMineField(30, 30, 99,500);
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


    public void LoseGame(int typeLoss) {
        if (typeLoss == 1) {
            // Hit a mine
            Debug.Log("hit a mine LOSER");

        } else if (typeLoss == 2) {
            // ran out of time
            Debug.Log("ran out of time LOSER");
        }

        gameStarted = false;
        losePanel.SetActive(true);

    }


    public void WinGame() {
        Debug.Log("win");
    }


    public void SubtractMine() {
        minesLeft--;
        topbar.mineCounter.text = minesLeft.ToString();
    }


    public void AddMine() {
        minesLeft++;
        topbar.mineCounter.text = minesLeft.ToString();
    }

}
