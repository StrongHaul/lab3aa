using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID = "Player ";
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void Registerplayer(string id, Player player)
    {
        string playerID = PLAYER_ID + id;
        players.Add(playerID, player);
        player.transform.name = playerID;
    }

    public static void Unregister(string playerID)
    {
        players.Remove(playerID);
    }

    public static Player Getplayer(string playerID)
    {
        return players[playerID];
    }
}
