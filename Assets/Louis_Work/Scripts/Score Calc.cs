using UnityEngine;

public class ScoreCalc : MonoBehaviour
{
    public float scorePercent;
    public float Fruit;
    public float Carbs;
    public float Protein;
    public float Dairy;
    public float Sugar;
    public bool isbalanced;
    [SerializeField] ParticleSystem VictoryParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VictoryParticle = GameObject.Find("Victory Particle System").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scorePercent <= 0f)
        {
            scorePercent = 0f;
        }
    }

    public void Variables()
    {
        if (Fruit == 1f)
        {
            scorePercent += 30f;
        }
        else if (Fruit < 1f || Fruit > 1f)
        {
            scorePercent -= 30f;
        }

        if (Carbs == 1f)
        {
            scorePercent += 30f;
        }
        if (Protein == 1f)
        {
            scorePercent += 20f;
        }
        if (Dairy == 1f)
        {
            scorePercent += 15f;
        }
        if (Sugar == 1f)
        {
            scorePercent += 5f;
        }

        if (scorePercent == 100f)
        {
            isbalanced = true;
            VictoryParticle.Play();
        }

        else if (scorePercent >= 101f || scorePercent <= 99f)
        {
            isbalanced = false;
        }
    }
}
