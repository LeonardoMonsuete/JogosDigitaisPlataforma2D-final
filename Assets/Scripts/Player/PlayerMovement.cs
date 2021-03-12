using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     private int speedParam = Animator.StringToHash("Speed");
    private int groudedParam = Animator.StringToHash("IsGrouded");

    public float speedForce = 12.0f;
    public float jumpForce = 5.0f;


    public bool IsGrounded = false;
    public Vector3 offset = Vector2.zero;
    public float raidios = 1.0f;
    public LayerMask layer;

    private Vector2 _input = Vector2.zero;
    private Vector2 _direction = Vector2.zero;
    public Vector2 _moviment = Vector2.zero;
    private Rigidbody2D _body = null;
    private Animator _animator = null;
    private SpriteRenderer _renderer = null;
    



    // Awake is called when the script instance is being loaded
    private void Awake()
    {        
        _body = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _moviment = new Vector2(Input.GetAxisRaw("Horizontal") * speedForce, 0.0f);
     
        if (_moviment.sqrMagnitude > 0.1f)
        {           
            _renderer.flipX = !(Input.GetAxis("Horizontal") > 0.0f);            
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        //_animator.SetFloat(speedParam, Mathf.Abs(_body.velocity.x));
       // _animator.SetBool(groudedParam, IsGrounded);
    }



    private void FixedUpdate()
    {

        IsGrounded = Physics2D.OverlapCircle(this.transform.position + offset, raidios, layer);

        if (_moviment.sqrMagnitude > 0.1f)
        {            
            _body.AddForce(_moviment, ForceMode2D.Force);
            Debug.Log("Aplicou força");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((this.transform.position + offset), raidios);

    }




}
