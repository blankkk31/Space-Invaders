using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // MOVE
    public float playerSpeed;
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().AddForce(new Vector2((horizontal * playerSpeed) * Time.deltaTime, 0));
    }

    // SHOOT
    [SerializeField] private float shootDelay;
    [SerializeField] private float shootTimer;
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private GameObject playerShootSpawn;
    private bool CanShoot()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            shootTimer = shootDelay;
            return true;
        }
        return false;
    }
    private void Shoot()
    {
        Instantiate(playerLaser, playerShootSpawn.transform.position, Quaternion.identity);
    }

    private void Start()
    {
        shootTimer = shootDelay;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }
}
