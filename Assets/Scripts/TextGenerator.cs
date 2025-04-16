using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGenerator : MonoBehaviour
{
    public Canvas TextCanva;
    public GameObject TextPrefap;
    public float TextDelay;
    void Start()
    {
        StartCoroutine(SpawnText());   
    }  
    IEnumerator SpawnText()
    {
        while (true)
        {
            Instantiate(TextPrefap, TextCanva.transform);
            yield return new WaitForSeconds(TextDelay);
        }
    }
}
