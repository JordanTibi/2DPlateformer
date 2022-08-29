using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;






public class PlayerMovement : MonoBehaviour
{

    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] Transform _root;
    [SerializeField] Transform _footPoint;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float _speed;
    [SerializeField] float _movingTreshold;
    [SerializeField] float _force;
    [SerializeField] float _jumpForce;
    [SerializeField] float _raycastLenght;
    [SerializeField] Animator _animator;

    public Transform Player;
    public TextMeshProUGUI scoreText;

    Vector2 _playerMovement;
    bool _isGrounded;

    
    

#if UNITY_EDITOR
    private void Reset()
    {
       _root = transform.parent;
       _speed = 2f;
       Debug.Log("Coucou l'editeur");
    }
#endif
    
    private void FixedUpdate()
    {
        Debug.Log(_playerMovement);

        //Movement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
        _root.transform.Translate(_playerMovement * Time.fixedDeltaTime * _speed, Space.World);

        //Animator
        Debug.Log($"Magnitude : {direction.magnitude}");
        if (direction.magnitude > _movingTreshold)    //Si on est en train de bouger
        {
            _animator.SetBool("IsWalking", true);
        }
        else                   //Sinon que l'on ne bouge pas donc false
        {
            _animator.SetBool("IsWalking", false);
        }

        // Orientation

        
        if(direction.x > 0)    //Right
        {
            _root.rotation = Quaternion.Euler(0, 0, 0);
            //_root.localScale = new Vector3(1, 1, 1);
        }
        else if(direction.x < 0)                    //Left
        {
            _root.rotation = Quaternion.Euler(0, 180, 0);
        }

        //Is Grounded

        Debug.DrawRay(_footPoint.position, Vector2.down * _raycastLenght, Color.red, 1f);
        int raycastLayerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(_footPoint.position, Vector2.down, _raycastLenght);

        if(hit.collider == null)
        {
            Debug.Log("J'ai rencontré PERSONNE");
            _isGrounded = false;
        }
        else
        {
            Debug.Log("J'ai TOUCHE QUELQU'UN");
            _isGrounded=true;
        }

        //SCORE UI

        {
            scoreText.text = Player.position.z.ToString("0");
        }
    }

    private void Start()
    {
        _moveInput.action.started += StartMove;  
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += EndMove;

        _jumpInput.action.started += JumpStart;
        
     }

    

    private void JumpStart(InputAction.CallbackContext obj)
    {
        if (_isGrounded)
        {

            Debug.Log("Coucou");

            rb.AddForce(new Vector2(0, _jumpForce));
        }
    }

  

    private void StartMove(InputAction.CallbackContext obj)
    {
        

       _playerMovement = obj.ReadValue<Vector2>();
       Debug.Log($"Appelé ! {_playerMovement}");
    }

    private void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        Debug.Log($"Joystick UPDATE ! {_playerMovement}");
    }
    private void EndMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        Debug.Log($"Joystick Annulé !");
    }
}
