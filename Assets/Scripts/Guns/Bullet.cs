using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage;

    public float speed;

    public Vector2 direction;

    public Vector2 EndPoint;

    private  Collider2D collider2d;

    public Gun gun;


    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();

        EndPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    private void Update()
    {

        Move();

        if (IsAfterEnd())
        {
            Finish();
        }

    }

    public void Move()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public bool IsAfterEnd()
    {
        if (transform.position.y - (collider2d.bounds.size.y) > EndPoint.y)
        {
            return true;
        }
        else return false;
    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }

    public void Broke()
    {
        Finish();
    }
}
