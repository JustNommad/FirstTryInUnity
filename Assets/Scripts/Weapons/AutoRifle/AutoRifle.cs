// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;

public class AutoRifle : MonoBehaviour
{

    public float speed = 20; // скорость пули
    public Rigidbody bullet; // префаб нашей пули
    public Transform gunPoint; // точка рождения
    public float fireRate = 1; // скорострельность
    private bool _facingRaight = true;

    public Transform zRotate; // объект для вращения по оси Z

    // ограничение вращения
    public float minAngle = -40;
    public float maxAngle = 40;

    private float curTimeout, angle;
    private int invert;
    private Vector3 mouse;

    void Start()
    {
        if(!_facingRaight)
        {
            invert = -1;
        }
        else
        {
            invert = 1;
        }
    }

    void SetRotation()
    {
        Vector3 mousePosMain = Input.mousePosition;
        mousePosMain.z = Camera.main.transform.position.y;
        mouse = Camera.main.ScreenToWorldPoint(mousePosMain);
        Vector3 lookPos = mouse - transform.position;
        angle = Mathf.Atan2(lookPos.y * invert, lookPos.x * invert) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        else
        {
            curTimeout = 100;
        }

        if (zRotate) SetRotation();

        float h = Input.GetAxis("Horizontal");

        if(angle == maxAngle && mouse.x < zRotate.position.x && _facingRaight)
        {
            transform.position = transform.position + new Vector3(-3, 0, 0);
            Flip();
        }
        else if(angle == maxAngle && mouse.x > zRotate.position.x && !_facingRaight)
        {
            transform.position = transform.position + new Vector3(3, 0, 0);
            Flip();
        }
    }

    public void Flip()
    {
        _facingRaight = !_facingRaight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        invert *= -1;
        transform.localScale = theScale;
    }

    public void Fire()
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > fireRate)
        {
            curTimeout = 0;
            Vector3 direction = gunPoint.position - transform.position;
            Rigidbody clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody;
            clone.velocity = transform.TransformDirection(direction.normalized * speed);
            clone.transform.right = direction.normalized;
        }
    }
}
