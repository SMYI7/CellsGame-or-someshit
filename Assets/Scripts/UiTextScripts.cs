using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTextScripts : MonoBehaviour
{
    private TMPro.TMP_Text tmp;
    public GameManager instance;
    public Transform spawner;
    public RectTransform tf;
    public float moveSpeed;
    public float rotationSpeed;
    private Vector2 Direction;
    public float minSize;
    public float maxSize;
    public float lifeTime;
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
        tmp = gameObject.GetComponent<TMPro.TMP_Text>();
        tf = GetComponent<RectTransform>();
        tf.position = spawner.position;
        instance = GameManager.instance;
        tmp.text = instance.alphapet[Random.Range(0, instance.alphapet.Length)].ToString();
        Invoke("Destoy", lifeTime);
        Direction = new Vector2(Random.Range(0, 1), Random.Range(0, -1));
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        Vector2 movingXYZ = moveSpeed * Direction;
        tf.anchoredPosition += movingXYZ;
    }
   void Destoy()
    {
        Destroy(gameObject);
    }
}
