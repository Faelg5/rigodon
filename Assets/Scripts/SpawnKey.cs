using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnKey : MonoBehaviour {

    private const int nbMaxSpawnKeys = 5;
    private static int nbKeysSpawned = 0;

    public float spawnDelay = 1f;
    public Component leftKey;
    public Component upKey;
    public Component rightKey;
    public Component downKey;
    public List<GameObject> Spawners;


    void Start()
    {
        Invoke("SpawnKeys", spawnDelay);
    }

    void SpawnKeys()
    {
        
        int rngKey = Random.Range(0, 4);
        int spawner = Random.Range(0, 3);

        Debug.Log(rngKey);

        switch (rngKey)
        {
            case 0:
                Instantiate(downKey, Spawners[spawner].transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(upKey, Spawners[spawner].transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(leftKey, Spawners[spawner].transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(rightKey, Spawners[spawner].transform.position, Quaternion.identity);
                break;
        }

        nbKeysSpawned++;

        if (nbKeysSpawned < (nbMaxSpawnKeys * LevelConfig.lvlModificator[0]) - Game.difficulty)
        {
            Invoke("SpawnKeys", spawnDelay);
        }
        else
        {
            Application.LoadLevel("LevelCompleted");
        }
    }
}
