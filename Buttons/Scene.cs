using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void GameLoad()
    {
        SceneManager.LoadScene("Game");
    }
}