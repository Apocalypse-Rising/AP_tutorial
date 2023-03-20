using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStuff : MonoBehaviour
{
    public System.DateTime startTime;
    public int highCombo;
    public int enemiesKilled;
    // Start is called before the first frame update
    private void Start()
    {
        startTime = System.DateTime.UtcNow;
        highCombo = 0;
        enemiesKilled = 0;
    }

    private void Again()
    {
        startTime = System.DateTime.UtcNow;
        highCombo = 0;
        enemiesKilled = 0;
    }

}
