using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public char[] alphapet;
    public List<char> usedAlpha;
    public char currentAlpha;
    private GameObject[] CellText;
    private GameObject[] Cells;
    public enum States
    {
        none,
        red,
        green
    }
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        string alph = "abcdefghijklmnopqrstuvwxyz";
        alphapet = alph.ToCharArray();
        CellText = GameObject.FindGameObjectsWithTag("Alpha");
        usedAlpha.Add(currentAlpha);
        _randomizer();
        Cells = GameObject.FindGameObjectsWithTag("Hex");
    }

    // Update is called once per frame
    void Update()
    {
        selectCell();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _randomizer();
            resetCells();
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
    void resetCells()
    {
        foreach(GameObject cell in Cells)
        {
            cell.GetComponent<CellScript>().currentState = States.none;
        }
    }
    void selectCell()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           // Ray mouseSelection = Camera.main.ScreenPointToRay(Input.mousePosition);
           Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitinfo = Physics2D.BoxCast(mousepos, 0.5f * Vector2.one, 0, Vector2.zero);
            if (hitinfo != null)
            {
                Debug.Log(hitinfo.collider);
                if (hitinfo.collider != null)
                {
                    CellScript cell = hitinfo.collider.gameObject.GetComponent<CellScript>();
                    if(cell != null)
                    {
                        switch(cell.currentState)
                        {
                            case States.none:
                                cell.currentState = States.green;
                                break;
                            case States.green:
                                cell.currentState = States.red;
                                break;
                            case States.red:
                                cell.currentState = States.none;
                                break;
                            default:
                                break;

                        }
                    }
                
                }
            }
        }

        }
    private void OnDrawGizmos()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawWireCube(mousepos, 0.5f * Vector2.one);
    }
}
