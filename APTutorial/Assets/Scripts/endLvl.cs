using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLvl : MonoBehaviour
{
    private sceneLoader loader;

    private void Start()
    {
        loader = gameObject.GetComponent<sceneLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.collider.tag == "Player")
        {
            loader.LoadScene("endLevel");
        }
    }
}
