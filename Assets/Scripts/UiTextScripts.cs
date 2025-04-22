using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
    public TMPro.TMP_FontAsset[] fontAssets;
    private void Awake()
    {
        Direction = new Vector2((Random.Range(0f, 1f)), (Random.Range(0f, -1f)));
    }
    void Start()
    {
        
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
        tmp = gameObject.GetComponent<TMPro.TMP_Text>();
        tf = GetComponent<RectTransform>();
        tf.position = spawner.position;
        instance = GameManager.instance;
        tmp.text = instance.alphapet[Random.Range(0, instance.alphapet.Length)].ToString();
        Invoke("Destoy", lifeTime);
        float rand = Random.Range(minSize, maxSize);
        tf.sizeDelta = new Vector2(rand , rand);
        tmp.font = fontAssets[Random.Range(0, fontAssets.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movingXYZ = moveSpeed * Direction;
        tf.Translate(movingXYZ);
        tf.rotation *= new Quaternion(0, 0, rotationSpeed, 0);
        //move();
    }
    private void move()
    {
        
    }
   void Destoy()
    {
        Destroy(gameObject);
    }
}
