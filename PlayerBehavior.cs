using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public float jumpVelocity = 5f;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private CapsuleCollider _col;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    private GameBehaviour _gameManager;
    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();


    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /**which movement do I like better**
        this.transform.Translate(Vector3.forward * vInput *
 Time.deltaTime);
        this.transform.Translate(Vector3.right * hInput *
 Time.deltaTime);
       
        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);*/
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,this.transform.position + new Vector3(1, 0, 0),this.transform.rotation) as GameObject;
            Rigidbody bulletRB =newBullet.GetComponent<Rigidbody>();
          
            bulletRB.velocity = this.transform.forward * bulletSpeed;

        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            playerJump();
        }
            Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation *
 Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position +
 this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

    }
  
    private bool IsGrounded()
    {
        
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);
        
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
        capsuleBottom, distanceToGround, groundLayer,
        QueryTriggerInteraction.Ignore);
        
        return grounded;
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Enemy")
        {
            
            _gameManager.HP -= 1;
        }
    }

}
