using UnityEngine;
using System.Collections;


[System.Serializable]
public class Game {

    enum GameDifficulty {ez = -1, normal, hard};

    public static Game current;
    public static string gameVersion = "v 0.0.1 Alpha";
    public static int difficulty = (int)GameDifficulty.ez;

}
