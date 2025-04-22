using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public GameManager.States currentState;
    SpriteRenderer SR;
    public Color red;
    public Color green;
    public Color grey;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case(GameManager.States.green):
                SR.color = green;
                break;
            case(GameManager.States.red): 
                SR.color = red;
                break;
            case (GameManager.States.none):
                SR.color = Color.white;
                break;
            case (GameManager.States.gery):
                SR.color = grey;
                break;
            default:
                break;
                
        }
    }
}
