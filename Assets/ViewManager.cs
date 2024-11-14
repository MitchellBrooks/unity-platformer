using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewManager : MonoBehaviour
{

    public void PlayScene(string sceneName) {
        Debug.Log("loading " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName) {
        Debug.Log("unloading " + sceneName);
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
