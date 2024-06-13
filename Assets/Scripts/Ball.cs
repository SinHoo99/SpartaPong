using Photon.Pun;
using UnityEngine;

public class Ball : MonoBehaviourPun
{
    public float speed;
    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            Launch();
        }
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidBody2D.velocity = new Vector2(x * speed, y * speed);
    }

    public void Reset()
    {
        if (photonView.IsMine)
        {
            rigidBody2D.velocity = Vector2.zero;
            transform.position = Vector2.zero;
            Invoke("Launch", 1);
        }
    }
}