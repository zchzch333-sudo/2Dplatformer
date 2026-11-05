
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 2f;

    private float startX;
    private bool movingRight = true;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        if (movingRight)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x >= startX + moveRange)
            movingRight = false;

        if (transform.position.x <= startX - moveRange)
            movingRight = true;
    }
}

