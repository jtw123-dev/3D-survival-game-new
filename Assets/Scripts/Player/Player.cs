using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] CharacterController _character;
    [SerializeField] Camera _camera;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    private float _yVelocity;
    [SerializeField] private float _gravity;
    [SerializeField] private float _cameraSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraController();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        

    }

    private void Movement()
    {
        float xPos = Input.GetAxis("Horizontal") * _speed;
        float zPos = Input.GetAxis("Vertical") * _speed;

        Vector3 direction = new Vector3(xPos, 0, zPos);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Space)&&_character.isGrounded==true)
        {
            _yVelocity = _jumpForce;
        }
        _yVelocity -= _gravity;

        direction.y = _yVelocity;
        _character.Move(direction*Time.deltaTime);
    }

    private void CameraController()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX;//could multiply camera sensitivity 

        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);

        Vector3 currentCameraRotation = _camera.transform.localEulerAngles;
        currentCameraRotation.x = Mathf.Clamp(currentCameraRotation.x, 13, 21) - mouseY;
        _camera.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCameraRotation.x, Vector3.right);
    }
}
