using UnityEngine;
using UnityEngine.InputSystem;

public class BasketMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        float input = moveAction.action.ReadValue<float>();

        Vector3 pos = transform.position;
        pos.x += input * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}