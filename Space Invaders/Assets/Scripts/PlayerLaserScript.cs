using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserScript : MonoBehaviour
{
    public float playerLaserSpeed;

    private void MoveUp()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerLaserSpeed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(this.gameObject, 3);
    }

    private void FixedUpdate()
    {
        MoveUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
