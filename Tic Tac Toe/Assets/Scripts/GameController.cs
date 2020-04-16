﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restartButton;
    void Awake() {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons() {
        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide() {
        return playerSide;
    }

    public void EndTurn() {
        moveCount++;
        // Linhas
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            GameOver(playerSide);
        }
        if(buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            GameOver(playerSide);
        }
        if(buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }
        // Diagonais
        if(buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }
        if(buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        }
        // Colunas
        if(buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        }
        if(buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            GameOver(playerSide);
        }
        if(buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }
        if(moveCount >= 9) {
            GameOver("draw");
        }
        ChangeSides();
    }

    public void GameOver(string winningPlayer) {
        SetBoardInteractable(false);
        restartButton.SetActive(true);
        if (winningPlayer == "draw") { 
            SetGameOverText("Empate!"); 
        } else { 
            SetGameOverText(winningPlayer + " Ganhou!"); 
        }
    }

    public void ChangeSides() {
        playerSide = playerSide == "X" ? "O" : "X";
    }

    public void SetGameOverText(string value) {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame() {
        playerSide = "X";
        moveCount = 0;
        
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);

        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].text = "";
        }
        restartButton.SetActive(false);
    }

    public void SetBoardInteractable(bool toggle) {
        for(int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}