using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    [SerializeField] private float linearSpeed;
    [SerializeField] private float rotationSpeed;
    
    private CharacterController _cc;
    private Vector3 _inputDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * _inputDirection.x * Time.deltaTime);
        _cc.Move(transform.forward * (linearSpeed * _inputDirection.y * Time.deltaTime));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }
}
