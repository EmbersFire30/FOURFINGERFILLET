using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SandwichBuilder : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject fillingPrefab;
    [SerializeField] private GameObject topSlicePrefab;

    [Header("Sizes")]
    [SerializeField] private float breadThickness = 0.4f;
    [SerializeField] private float fillingThickness = 0.3f;

    [Header("Rules")]
    [SerializeField] private int maxFillings = 3;
    [SerializeField]
    private Color[] groupColours =
    {
        new Color(0.40f, 0.70f, 0.30f),
        new Color(0.98f, 0.80f, 0.25f),
        new Color(0.93f, 0.45f, 0.55f),
        new Color(0.35f, 0.60f, 0.90f),
        new Color(0.60f, 0.40f, 0.75f),
        new Color(0.55f, 0.35f, 0.25f)
    };

    [Header("Finishing")]
    [SerializeField] private GameObject[] stopWhenDone;
    [SerializeField] private float dropHeight = 3f;
    [SerializeField] private float dropTime = 0.4f;
    [SerializeField] private float waitBeforeResults = 2f;
    [SerializeField] private string resultsSceneName = "ResultsScene";

    private BoxCollider2D catchZone;
    private int fillingCount = 0;
    private float stackHeight;
    private bool isComplete = false;

    private void Start()
    {
        catchZone = GetComponent<BoxCollider2D>();
        stackHeight = breadThickness / 2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isComplete)
        {
            return;
        }

        Food food = other.GetComponent<Food>();
        if (food == null)
        {
            return;
        }

        AddFilling(food.Group);
        Destroy(other.gameObject);

        if (fillingCount >= maxFillings)
        {
            isComplete = true;
            StartCoroutine(FinishSandwich());
        }
    }

    private void AddFilling(FoodGroup group)
    {
        LunchTracker.Add(group);

        GameObject filling = Instantiate(fillingPrefab, transform);
        filling.transform.localPosition = new Vector3(0f, stackHeight + fillingThickness / 2f, 0f);
        filling.GetComponent<SpriteRenderer>().color = groupColours[(int)group];

        stackHeight += fillingThickness;
        fillingCount++;

        catchZone.offset = new Vector2(0f, stackHeight - breadThickness / 2f);
    }

    private IEnumerator FinishSandwich()
    {
        foreach (GameObject thing in stopWhenDone)
        {
            if (thing != null)
            {
                Destroy(thing);
            }
        }

        GameObject topSlice = Instantiate(topSlicePrefab, transform);
        Vector3 endPos = new Vector3(0f, stackHeight + breadThickness / 2f, 0f);
        Vector3 startPos = endPos + new Vector3(0f, dropHeight, 0f);

        float timer = 0f;
        while (timer < dropTime)
        {
            timer += Time.deltaTime;
            topSlice.transform.localPosition = Vector3.Lerp(startPos, endPos, timer / dropTime);
            yield return null;
        }
        topSlice.transform.localPosition = endPos;

        yield return new WaitForSeconds(waitBeforeResults);
        SceneManager.LoadScene(resultsSceneName);
    }
}