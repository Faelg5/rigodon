using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNote : MonoBehaviour {

    public Component wNote;
    public Component bNote;
    public List<GameObject> Spawners;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Spawn");
            int noteKey = Random.Range(0, 2);
            SpawnNotes(noteKey);
        }

    }

    void SpawnNotes(int noteKey)
    {

        int spawner = Random.Range(0, 3);
        if (noteKey == 0)
        {
            Instantiate(bNote, Spawners[spawner].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(wNote, Spawners[spawner].transform.position, Quaternion.identity);
        }
    }
}
