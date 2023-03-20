using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private ComboCount comboGet;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        comboGet = player.GetComponent<ComboCount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            comboGet.comboNum += 1;
        }
        
    }
}
