
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        Debug.Log("SCENE");
        SceneManager.LoadScene(sceneName);
    }
}
