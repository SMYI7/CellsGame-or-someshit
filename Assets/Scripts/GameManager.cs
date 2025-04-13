using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public char[] alphapet;
    public List<char> usedAlpha;
    public char currentAlpha;
    private GameObject[] CellText;
    void Start()
    {
        string alph = "abcdefghijklmnopqrstuvwxyz";
        alphapet = alph.ToCharArray();
        CellText = GameObject.FindGameObjectsWithTag("Alpha");
        usedAlpha.Add(currentAlpha);
        _randomizer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _randomizer();
            
        }
    }
    void randomAlpha()
    {
        currentAlpha = alphapet[Random.Range(0, alphapet.Length)];
    }
    public void _randomizer()
    {

        usedAlpha.Clear();
        for (int i = 0; i < CellText.Length; i++)
        {
            for (int j = 0; j < usedAlpha.Count; j++)
            {

                while (currentAlpha == usedAlpha[j])
                {
                    randomAlpha();
                }
                    foreach(char c in usedAlpha)
                    {
                        if (currentAlpha == c)
                        {
                            randomAlpha();
                        }
                    }
            }
            CellText[i].GetComponent<TMPro.TMP_Text>().text = currentAlpha.ToString().ToUpper();
            usedAlpha.Add(currentAlpha);
        }
    }
}
