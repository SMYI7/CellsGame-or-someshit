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
    public Color Lightgrey;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(currentState)
        {
            case (GameManager.States.lightGrey):
                StartCoroutine(lightGreyTimer());
                break;
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
    IEnumerator lightGreyTimer()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitinfo = Physics2D.BoxCast(mousepos, 0.5f * Vector2.one, 0, Vector2.zero);
                
        SR.color = Lightgrey;
        float lerpamount = 0;
        Color white = Color.white;

        if (hitinfo.collider != gameObject)
        {
            while (currentState == GameManager.States.lightGrey && SR.color != Color.white)
            {


                white.r = Mathf.Lerp(Lightgrey.r, Color.white.r, lerpamount);
                white.g = Mathf.Lerp(Lightgrey.g, Color.white.g, lerpamount);
                white.b = Mathf.Lerp(Lightgrey.b, Color.white.b, lerpamount);

                Debug.Log(white + " " + lerpamount);
                SR.color = white;
                lerpamount += 0.01f;
                lerpamount = Mathf.Clamp(lerpamount, 0, 1);
                yield return new WaitForSeconds(0.05f);
            }
            if (currentState == GameManager.States.lightGrey && SR.color == Color.white)
            {
                currentState = GameManager.States.none;
            }
        }
        else
        {
            SR.color = Lightgrey;
        }
    }
}
