using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private  CharacterController _character;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private float _yVelocity;
    [SerializeField] private float _gravity;
    [SerializeField] private float _cameraSensitivity;
    [SerializeField] private int _health;
    private bool _isDead;

    public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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

        if (_health<=0)
        {
            _isDead = true;
            Destroy(gameObject);
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

    public void Damage()
    {
        if(_isDead==false)
        {
            _health--;
        }
        else
        {
            return;
        }  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="EnemyCollider")
        {
            Damage();
        }
    }
}
