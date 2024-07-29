using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public float upForce = 18f;
    private bool isDead = false;
    public Rigidbody2D rb2d;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
            rb2d.velocity = Vector2.up * upForce;

        if (transform.position.y > 10 || transform.position.y < -10)
            logic.gameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isDead = true;
    }
}
