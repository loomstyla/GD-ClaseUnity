using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float _moveSpeed = 50f;
    public bool _canjump;
    public float _vertical;
    public float _horizontal;
    private Vector3 direccion;
    public float _jumpForce;
    public Rigidbody rb;
    public Vector3 jump;
    public Vector3 walljump1;
    public Vector3 walljump2;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        _canjump = true;
    }

    // Update is called once per frame
    void Update()
    {

        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(mH * _moveSpeed, rb.velocity.y, mV * _moveSpeed);
        Jump();
    }

    public void Jump()
    {


        if (_canjump == true && Input.GetKeyDown(KeyCode.Space))
        {
            _canjump = false;
            rb.AddForce(jump * _jumpForce, ForceMode.Impulse);

        }


    }
    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        _canjump = true;
        if (collision.gameObject.CompareTag("bounce1"))
        {
            _canjump = true;
            
            if (_canjump == true && Input.GetKeyDown(KeyCode.Space)) 
            {
                rb.AddForce(walljump1 * _jumpForce, ForceMode.Impulse);

            }
        }
        if (collision.gameObject.CompareTag("bounce2"))
        {
            _canjump = true;

            if (_canjump == true && Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(walljump2 * _jumpForce, ForceMode.Impulse);
                

            }
        }

    }
     void OnCollisionEnter()
    {
        _canjump = true;
    }

}
