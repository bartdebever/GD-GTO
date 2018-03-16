using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public List<Player> Players;
    private int currentPlayer;

    public void NextPlayer()
    {
        this.GetCurrentPlayer().TurnEnd();
        this.currentPlayer++;
        this.GetCurrentPlayer().TurnStart();
    }

    public Player GetCurrentPlayer()
    {
        return this.Players[this.currentPlayer];
    }
}
