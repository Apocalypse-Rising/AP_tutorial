
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        if (sceneName.Equals("Level "))
        {
            int lev = PlayerPrefs.GetInt("Level");
            lev += 1;
            PlayerPrefs.SetInt("Level", lev);
            PlayerPrefs.Save();
            SceneManager.LoadScene(sceneName + lev.ToString());
        } else if (sceneName.Equals("Game Over"))
        {
            int lev = PlayerPrefs.GetInt("Level");
            SceneManager.LoadScene("Level " + lev.ToString());
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
