using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    [SerializeField ]private GameObject CurrentFood;
    private Rigidbody ApBody;
    public Collider[] ApCollider;
    public Vector3 ApTransform;
    public float Apx;
    public float Apz;
    public float Apy;
    public float ApRotate;
    public bool CanMove;
    public bool IsSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ApCollider = CurrentFood.GetComponentsInChildren<BoxCollider>();
        //ApTransform = new Vector3(Apx, Apy, Apz);
        Apy = 2.5f;
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected)
        {
            SelectedObject();
        }

        //Debug.Log(CanPlace);
    }

    public void SelectedObject()
    {
        //IDEA: Once an object has been placed - CHANGE the rigidbody to the next object.
        //OR Whatever object player clicks on, the rigidbody = that Object's rigidbody
        ApBody.transform.position = ApTransform;
        ApTransform = new Vector3(Apx, Apy, Apz);

        if (Input.GetKeyDown(KeyCode.W) && CanMove)
        {
            Apz += 1f;
        }

        if (Input.GetKeyDown(KeyCode.S) && CanMove)
        {
            Apz -= 1f;
        }

        if (Input.GetKeyDown(KeyCode.A) && CanMove)
        {
            Apx -= 1f;
        }

        if (Input.GetKeyDown(KeyCode.D) && CanMove)
        {
            Apx += 1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ApRotate += 90f;
            ApBody.transform.Rotate(0, ApRotate, 0);

            if (ApRotate >= 270f)
            {
                ApRotate = 0;
            }
        }

        //if (CanPlace) //&& !CannotPlace)
        //{
        //    Debug.Log("C'mon, please work!");

        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        CanMove = false; //Won't work for multiple objects... need new solution! Maybe tags or Array can help? Need the opposite of a Foreach loop...
        //        Apy = 1.5f;
        //        //IsSelected = false;
        //        //CurrentFood = null;
        //    }
        //}
    }

    public void Place()
    {
        Debug.Log("PLACE ME MOMMY");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SetNull());
        }
    }

    public void OnMouseDown()
    {
        IsSelected = true;
        CurrentFood = gameObject;
        CanMove = true;
        ApBody = CurrentFood.GetComponent<Rigidbody>();
        Apy = 2.5f;
    }

    IEnumerator SetNull()
    {
        CanMove = false; //Won't work for multiple objects... need new solution! Maybe tags or Array can help? Need the opposite of a Foreach loop...
                         //Set Null may just work anyways...
        Apy = 1.5f;

        yield return new WaitForSeconds(0.5f);

        ApBody.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(0.5f);

        IsSelected = false;
        //CurrentFood = null;
    }
}
