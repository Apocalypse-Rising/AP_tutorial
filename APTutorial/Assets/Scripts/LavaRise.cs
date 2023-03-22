using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    private ComboCount comboGet;
    private int comboNum;
    public bool damaged;
    private float time = 1.0f;
    private float start;
    private float end;
    // Start is called before the first frame update
    void Start()
    {
        damaged = false;
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        comboGet = player.GetComponent<ComboCount>();
        comboNum = comboGet.comboNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            rb.velocity = new Vector2(0, speed * 2.5f);
            
        }
        else
        {
            comboNum = comboGet.comboNum;
            if (comboNum >= 5)
            {
                rb.velocity = new Vector2(0, speed * 0.5f);
            }
            else
            {
                rb.velocity = new Vector2(0, speed);
            }
        }
    }

}