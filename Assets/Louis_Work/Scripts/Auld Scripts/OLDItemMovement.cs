using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class OLDItemMovement : MonoBehaviour
{
    [SerializeField ]private GameObject CurrentFood;
    private Rigidbody ApBody;
    public Collider[] ApCollider;
    public Vector3 ApTransform;
    public float Apx;
    public float Apz;
    public float Apy;
    public float ApRotate;
    public bool CanPlace;
    public bool CannotPlace;
    public bool CanMove;
    public bool IsSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ApCollider = CurrentFood.GetComponentsInChildren<BoxCollider>();
        //ApTransform = new Vector3(Apx, Apy, Apz);
        Apy = 2.5f;
        CanMove = true;
        CannotPlace = false;
        CurrentFood = gameObject;
        ApBody = CurrentFood.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

        Debug.Log(CanPlace);

        if (CanPlace) // && !CannotPlace)
        {
            Debug.Log("C'mon, please work!");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CanMove = false; //Won't work for multiple objects... need new solution! Maybe tags or Array can help? Need the opposite of a Foreach loop...
                Apy = 1.5f;
                //IsSelected = false;
                //CurrentFood = null;
            }
        }
    }
}
