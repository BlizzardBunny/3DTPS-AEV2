using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterLocomotion : MonoBehaviour
{
    [SerializeField] float playerHitPoints = 100f;
    [SerializeField] Image image;
    [SerializeField] Image death;
    [SerializeField] float flashSpeed = 5f;

    Animator animator;
    Vector2 input;
    Color visibColor, invisibColor;
    bool isAlive = true;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        visibColor = new Color(image.color.r, image.color.g, image.color.b, 127);
        invisibColor = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            animator.SetFloat("inputX", input.x);
            animator.SetFloat("inputY", input.y);
        }
        else
        {
            Die();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (image.color.a <= 0.05f)
            {
                image.color = visibColor;
                playerHitPoints -= 10;

                if (playerHitPoints == 0)
                {
                    isAlive = false;
                }
            }
            else
            {
                image.color = Color.Lerp(image.color, invisibColor, flashSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        image.color = invisibColor;
    }

    private void Die()
    {
        death.color = Color.Lerp(death.color, Color.black, flashSpeed * Time.deltaTime);

        if (death.color.a >= 0.9)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
//www.youtube.com/watch?v=ND1orPLw5EQ
