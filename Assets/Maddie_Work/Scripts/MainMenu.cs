using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string firstSceneName = "CatchScene";

    public void StartGame()
    {
        LunchTracker.ResetCounts();
        SceneManager.LoadScene(firstSceneName);
    }
}