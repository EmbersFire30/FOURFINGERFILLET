using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float destroyBelowY = -6f;
    [SerializeField] private FoodGroup foodGroup;

    public FoodGroup Group
    {
        get { return foodGroup; }
    }

    void Update()
    {
        if (transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            Debug.Log("Caught " + name);
            LunchTracker.Add(foodGroup);
            Destroy(gameObject);
        }
    }
}