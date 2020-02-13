using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomePlayerController : MonoBehaviour
{
    Camera cam;
    Vector3 clickPos;
    Rigidbody2D rb;

    private void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        clickPos = transform.position;
    }
    void Update()
    {
        MovetoPos();
    }

    void MovetoPos()
    {
            if (Input.GetMouseButtonDown(0))
            {
                clickPos.x = Input.mousePosition.x;

                if (clickPos.x < transform.position.x)
                {
                    MoveLeft();
                }
                else if (clickPos.x > transform.position.x)
                {
                    MoveRight();
                }
                else
                {
                    SetVelocityZero();
                }
            }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float middle = Screen.width / 2;


            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
                {
                    MoveLeft();
                }
                else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
                {
                    MoveRight();
                }
                else
                {
                    SetVelocityZero();
                }
        }
    }
    public void MoveRight()
    {

        rb.transform.Translate(Vector3.right * 5 * Time.deltaTime);
    }

    public void MoveLeft()
    {

        rb.transform.Translate(Vector3.left * 5 * Time.deltaTime);
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector3.zero;
    }
}
