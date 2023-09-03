using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    #region MoveProperties

    [SerializeField]
    float horizontalInput;

    [SerializeField]
    float verticalInput;

    [SerializeField]
    float speed;

    #endregion

    #region JumpProperties

    [SerializeField]
    bool isGrounded;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float fallMultiplier;

    [SerializeField]
    float gravityForce;

    #endregion

    [SerializeField]
    new Rigidbody rigidbody;

    [SerializeField]
    PlayerManager PlayerManager;

    [SerializeField]
    ControlSelectionEnum ControlSelection;


    void Awake()
    {
        PlayerManager = GetComponent<PlayerManager>();
        ControlSelection = PlayerManager.ControlSelection;
    }

    void Start()
    {        
        speed = 5f;
        jumpForce = 5f;
        fallMultiplier = 1.5f;
        rigidbody = GetComponent<Rigidbody>();
        gravityForce = Physics.gravity.y * fallMultiplier;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }

    private void Move()
    {
        horizontalInput = 0;
        verticalInput = 0;

        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += gravityForce * Time.deltaTime * Vector3.up;
        }
        if (ControlSelection == ControlSelectionEnum.Keyboard)
        {
            KeyboardMove();
            JumpKeyboard();
        }
        else if(ControlSelection == ControlSelectionEnum.Keyboard2)
        {
            Keyboard2Move();
            JumpKeyboard2();
        }
    }

    private void KeyboardMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(speed * Time.deltaTime * movement);
    }

    private void Keyboard2Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(speed * Time.deltaTime * movement);
    }

    private void JumpKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void JumpKeyboard2()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
