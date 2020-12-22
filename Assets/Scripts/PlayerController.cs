using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody rb;
    private int score = 0;
    public int health = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed;
        verticalMovement = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector3(horizontalMovement, 0f, verticalMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
            Debug.Log("You win!");
    }
}
