using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Animator anim;
    public DynamicJoystick joystick;
    public float speed = 2f;

    Rigidbody2D rb;
    Vector2 direction;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();




    }

    private void FixedUpdate()
    {

        direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);

    }


    void Update()
    {
        if(direction != new Vector2(0, 0))
        {
            if(direction.x >= 0f)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (direction.y >= 0f)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if(anim.GetInteger("anim") == 0)
            {
                 anim.SetInteger("anim", 1);
            }
        }
        else
        {
            anim.SetInteger("anim", 0);
        }
           
    }
}
