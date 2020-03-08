using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCannon : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] Rigidbody2D bullet;
    private void Update()
    {
        LookAtMouse();
        ShootBullet();
    }

    void LookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            bulletInstance.velocity = transform.right * maxSpeed;
        }
    }
}
