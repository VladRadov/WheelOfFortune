using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    public void LoadScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }
}