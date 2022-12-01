using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMinigame
{
    public class PlayerHotDogHandlerData
    {
        int amountEaten;
        float currentTime;

        public void SetAmountEaten(int amountEaten)
        {
            this.amountEaten = amountEaten;
        }

        public void SetCurrentTimer(float currentTime)
        {
            this.currentTime = currentTime;
        }

        public float GetCurrentTime()
        {
            return this.currentTime;
        }

        public int GetAmountEaten()
        {
            return this.amountEaten;
        }
    }

    public class Opponent
    {
        int amountEaten;

        public void SetAmountEaten(int amountEaten)
        {
            this.amountEaten = amountEaten;
        }

        public int GetAmountEaten()
        {
            return this.amountEaten;
        }
    }

    PlayerHotDogHandlerData playerHandler = new PlayerHotDogHandlerData();

    Opponent opponent = new Opponent();


    int playerHandlerVisited = -1;
    int opponentVisited = -1;

    public void SetPlayerHotDogHandler(PlayerHotDogHandlerData data)
    {
        this.playerHandler = data;
    }

    public PlayerHotDogHandlerData GetPlayerHotDogHandler()
    {
        return this.playerHandler;
    }

    public void SetOpponent(Opponent data)
    {
        this.opponent = data;
    }

    public Opponent GetOpponent()
    {
        return this.opponent;
    }

    public bool VisitedPlayerHandlerData()
    {
        playerHandlerVisited++;
        return playerHandlerVisited > 0;
    }

    public bool VisistedOpponent()
    {
        opponentVisited++;
        return opponentVisited > 0;
    }

}
