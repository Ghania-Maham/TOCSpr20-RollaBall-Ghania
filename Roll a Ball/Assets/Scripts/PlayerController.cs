﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //movement speed in units per second
    public float speed;
    private Rigidbody rb;
    public AudioSource sound;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        string getText = other.gameObject.GetComponent<CubeText>().nameLable.text.ToString();
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (PalindromeString(getText) == true)
            {
                other.gameObject.SetActive(false);
                sound.Play();
                count ++;
                SetCountText();
            }

        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        
        if (count ==1)
        {
            winText.text = "Player hits  the First Palindrome";
        }
        if (count == 2)
        {
            winText.text = "Player hits  the Second Palindrome";
        }
        if (count == 3)
        {
            winText.text = "Player hits  the Third Palindrome";
        }
        if (count == 4)
        {
            winText.text = "Player hits  the Forth  Palindrome";
        }
        if (count == 5)
        {
            winText.text = "Player hits  the Forth  Palindrome";
        }
        if (count == 6)
        {
            winText.text = "Player hits  the Forth  Palindrome";
        }


    }
    public bool PalindromeString(string input)
    {
        bool getText = true;
        for (int i = 0; i < (input.Length / 2 + 1); i++)
        {
            if (!(input[i] == input[input.Length - i - 1]))
            {
                getText = false;
                break;
            }
        }
        return getText;
    }

}