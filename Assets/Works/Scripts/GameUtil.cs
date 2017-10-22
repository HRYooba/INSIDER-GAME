using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insider
{

    public enum Status
    {
        Common,
        Insider,
        Master
    }

    static class Settings
    {
        static private int playerCount = 4;
        static private List<Status> playerList = new List<Status>();
        static public void SetPlayerCount(int num)
        {
            playerCount = num;
        }
        static public int GetplayerCount()
        {
            return playerCount;
        }
        static public void CreatePlayerList()
        {
            for (int i = 0; i < playerCount; i++)
            {
                playerList.Add(Status.Common);
            }

            int insiderNum = (int)Random.Range(0, playerCount);
            playerList[insiderNum] = Status.Insider;
            Answer.insider = insiderNum;

            int masterNum = (int)Random.Range(0, playerCount);
            while (masterNum == insiderNum)
            {
                masterNum = (int)Random.Range(0, playerCount);
            }
            playerList[masterNum] = Status.Master;
        }

		static public void DestroyPlayerList() {
			playerList.Clear();
		}

        static public void CreateTheme()
        {
            int id = (int)Random.Range(0, Const.THEMA.Length);
            Answer.theme = Const.THEMA[id];
        }

        static public Status GetPlayerStatus(int id)
        {
            return playerList[id];
        }
    }

    static class Answer
    {
        static public string theme;
        static public int insider;
    }

    static public class Const
    {
        static public readonly string[] THEMA = {
            "牛乳",
            "アイス"
        };
    }

}
