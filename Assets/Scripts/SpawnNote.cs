using UnityEngine;
using System.Collections;

public class SpawnNote : MonoBehaviour {

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

        var target = gameObject.GetComponent("SpawnNote");
        Debug.Log("Note key :" + noteKey);
        if (noteKey == 0)
        {
            Instantiate(target, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(target, transform.position, Quaternion.identity);
        }
    }
}
