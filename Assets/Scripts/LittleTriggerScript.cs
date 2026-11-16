using UnityEngine;

public class LittleTriggerScript : MonoBehaviour
{
    FoodTrigger Foodie;
    public int LittleBlocks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Foodie = GetComponentInParent<FoodTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        //Foodie.PlaceableBlocks = LittleBlocks;

        Debug.Log("Little Blocks= " + LittleBlocks);

        if (LittleBlocks >= 1)
        {
            LittleBlocks = 1;
            Foodie.PlaceableBlocks = 1;
        }
        else if (LittleBlocks <= 0)
        {
            LittleBlocks = 0;
            Foodie.PlaceableBlocks = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FreeSpace") && !other.CompareTag("LiamNeeson"))
        {
            Debug.Log("FREE SPACE");

            LittleBlocks = 1;

            //Item.CanPlace = true;
        }
        else if (other.CompareTag("LiamNeeson") && !other.CompareTag("FreeSpace"))
        {
            Debug.Log("NOT PLACEABLE");

            LittleBlocks = 0;

            //Item.CannotPlace = true;
        }
    }
}
