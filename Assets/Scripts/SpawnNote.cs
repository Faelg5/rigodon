using UnityEngine;
using System.Collections;

public class SpawnNote : MonoBehaviour {

    public GameObject[] target;
    public Component wNote;
    public Component bNote;

    void Start()
    {
    }

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

        Debug.Log("Note key :" + noteKey);
        if (noteKey == 0)
        {
            Instantiate(bNote, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(wNote, transform.position, Quaternion.identity);
        }
    }
}
