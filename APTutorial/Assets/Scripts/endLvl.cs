using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLvl : MonoBehaviour
{
    private sceneLoader loader;
    private float time;

    private void Start()
    {
        loader = gameObject.GetComponent<sceneLoader>();
        time = Time.deltaTime;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.collider.tag == "Player")
        {
            loader.LoadScene("endLevel");
            PlayerPrefs.SetFloat("Time", time);
            PlayerPrefs.Save();
        }
    }
}
