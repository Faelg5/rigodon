using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNote : MonoBehaviour {

    private const int nbMaxSpawnNote = 5;
    private static int nbNoteSpawned = 0;

    public float spawnDelay = 3f;
    public Component wNote;
    public Component bNote;
    public List<GameObject> Spawners;


    void Start()
    {
        Invoke("SpawnNotes", spawnDelay);
    }

    void SpawnNotes()
    {

        int noteKey = Random.Range(0, 2);
        int spawner = Random.Range(0, 3);
        if (noteKey == 0)
        {
            Instantiate(bNote, Spawners[spawner].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(wNote, Spawners[spawner].transform.position, Quaternion.identity);
        }

        nbNoteSpawned++;

        if(nbNoteSpawned < (nbMaxSpawnNote * LevelConfig.lvlModificator[0]) - Game.difficulty)
        {
            Invoke("SpawnNotes", spawnDelay);
        }
        else
        {
            Application.LoadLevel("GameOver");
        }
    }
}
