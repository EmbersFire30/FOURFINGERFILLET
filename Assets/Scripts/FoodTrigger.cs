using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    public ItemMovement Item;
    //public OLDItemMovement Item;
    public Collider[] BlocksInPlay;
    public int PlaceableBlocks;

    //public GameObject ParentObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item = gameObject.GetComponentInParent<ItemMovement>();
        //Item = GameObject.FindGameObjectWithTag("Banana").GetComponentInParent<OLDItemMovement>();
        //BlocksInPlay = gameObject.GetComponentsInChildren<Collider>();
        //PlaceableBlocks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Placeable Blocks: " + PlaceableBlocks);

        //if (PlaceableBlocks <= 0)
        //{
        //    PlaceableBlocks = 0;
        //    Item.CanPlace = false;
        //}

        if (PlaceableBlocks >= 1)
        {
            //Item.CanPlace = true;
            Item.Place();
        }
        else
        {
            Debug.Log("Fuck you game");
            //Item.CanPlace = false;
        }


        //if (PlaceableBlocks >= BlocksInPlay.Length)
        //{
        //    PlaceableBlocks = BlocksInPlay.Length;
        //    Item.CanPlace = true;
        //}
        //else if (PlaceableBlocks < BlocksInPlay.Length)
        //{
        //    Item.CanPlace = false;
        //}
    }

    private void OnTriggerStay(Collider other)
    {

        //if (other.CompareTag("FreeSpace"))
        //{
        //    Item.CanPlace = true;
        //}
        //else if (!other.CompareTag("FreeSpace"))
        //{
        //    Item.CanPlace = false;
        //}
    }
}
