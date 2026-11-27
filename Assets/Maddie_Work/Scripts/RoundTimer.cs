using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    [SerializeField] private float roundLength = 30f;
    [SerializeField] private string nextSceneName = "SandwichScene";
    [SerializeField] private TMP_Text timerText;

    private float timeLeft;
    private bool hasEnded = false;

    private void Start()
    {
        timeLeft = roundLength;
    }

    private void Update()
    {
        if (hasEnded)
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(Mathf.Max(timeLeft, 0f)).ToString();
        }

        if (timeLeft <= 0f)
        {
            hasEnded = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}