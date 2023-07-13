using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _joystickPos;
    float _horizontal;
    float _vertical;
    public float speed=10;
    public float lerpRotateSpeed = 10;
    public DynamicJoystick dynamicJoystick;
    Vector3 _endPointPos;

    private void OnEnable()
    {
        EventManager.EndPointPosition += EndPointPosition;
    }
    private void OnDisable()
    {
        EventManager.EndPointPosition -= EndPointPosition;
    }
    void EndPointPosition(Vector3 endPos)
    {
        _endPointPos=endPos;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }
    

    void Update()
    {
        JoystickControl();
        PositionControl();

    }
    void MoveKeybord()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(_horizontal, 0, _vertical);
        _rb.AddForce(vec * speed * Time.deltaTime);
    }
    void JoystickControl()
    {
        if (Input.GetMouseButton(0))
        {
            _horizontal = dynamicJoystick.Horizontal;
            _vertical = dynamicJoystick.Vertical;
            _joystickPos = new Vector3(_horizontal, 0, _vertical);
            //transform.position += _joystickPos;
            _rb.AddForce(_joystickPos * speed * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation(_joystickPos);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _rb.velocity = Vector3.zero;
        }
    }
    void PositionControl()
    {
        if (transform.position.z >= _endPointPos.z)
        {
            speed = 0;
        }
    }
}
