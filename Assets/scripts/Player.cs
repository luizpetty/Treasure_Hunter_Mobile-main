using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    public bool ativo = false;
    float rot;
    private int score;

    public GameObject mensagem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        ativo = false;
        moveSpeed = 0;
    }

    public void setAtivo(bool estado_player)
    {
        if (estado_player == true)
        {
            ativo = true;
            moveSpeed = 2;
        }
        else
        {
            ativo = false;
            moveSpeed = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ativo)
            return;

        rot = 0;
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < 0 || Input.GetKey(KeyCode.LeftArrow))
            {
                rot = rotateAmount;
            }
            else if (mousePos.x > 0 || Input.GetKey(KeyCode.RightArrow))
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = this.transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vel = rb.velocity;
        if ( (collision.gameObject.tag == "Joia"))
        {
            Destroy(collision.gameObject);
            score++;
            Debug.Log("score: " + score);
            if (score > 4)
            {
                Debug.Log("Level complete");
                mensagem.SetActive(true);
            }
            // transform.Rotate(0, 0, 0);
            rb.angularVelocity = 0;

        }
        else if ( (collision.gameObject.tag == "Danger") || (collision.gameObject.tag == "limite_tela"))
        {
            SceneManager.LoadScene("Game");
        }
       

    }
}
