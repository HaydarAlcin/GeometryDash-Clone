using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Transactions")]
    [SerializeField]
    float _xSpeed;
    [SerializeField]
    float _yForce;
    [SerializeField]
    float _yVelocity;
    public static bool _isGrounded;
    public bool isTouchThePortal;
    Rigidbody2D _rb;
    
    

    [Header("Rotational Transactions")]
    [SerializeField]
    GameObject _childPlayer;
    private bool isRotating = false;
    public float rotationAmount = 90.0f;
    public float rotationDuration = .1f; // Dönme süresi


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.5f;
        gameObject.SetActive(true);
    }

   

    private void Update()
    {
        XMovement();
        if (isTouchThePortal == false)
        {
            JumpAction();
        }
        else
        {
            SecondStage();
        }
        
    }

    public void XMovement()
    {
        transform.Translate(new Vector2(_xSpeed * Time.deltaTime, 0));
    }

    public void JumpAction()
    {
        if (Input.GetMouseButton(0) && _isGrounded==true)
        {
            _rb.AddForce(new Vector2(0, _yForce),ForceMode2D.Impulse);
            _isGrounded = false;
            RotatePlayer();

        }
        _rb.velocity += Vector2.up * Physics2D.gravity.y * (1.4f) * Time.deltaTime;
    }

    public void SecondStage()
    {
        if (Input.GetAxis("Fire1")>0)
        {
            
            _rb.velocity = new Vector2(0, _yVelocity);
        }
        _rb.velocity += Vector2.up * Physics2D.gravity.y * (1.5f) * Time.deltaTime;
    }


    public void RotatePlayer()
    {
        isRotating = true;

        
        _childPlayer.transform.DORotate(new Vector3(0.0f, 0.0f, _childPlayer.transform.eulerAngles.z + rotationAmount), rotationDuration)
            .OnComplete(() => isRotating = false);
    }
}
