using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float newMoveSpeed;
    public float rotSpeed;
    public Rigidbody rigidBody;
    public float jumpForce;
    public float timer;
    public int score;
    public bool startTime = false;
    public Text speedText;
    public Text scoreText;
    public Text timerText;


    public float speedDuration = 3f;




    // Start is called before the first frame update

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        newMoveSpeed = moveSpeed;

        speedText = GameObject.Find("SpeedText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0,0, translation);
        transform.Rotate(0, rotation, 0);


        if(Input.GetButton("Jump"))
        {
            rigidBody.AddForce(new Vector3(0, jumpForce, 0));
        }

         if (startTime)
        {
            timer += Time.deltaTime;
            if (timer >= speedDuration)
            {
                newMoveSpeed = moveSpeed; // Reset speed after duration
                startTime = false;
                timer = 0f;
        }
    }
    
     UpdateUIText();
    }

    void UpdateUIText()
    {
        speedText.text = "Speed: " + newMoveSpeed.ToString("F2");
        scoreText.text = "Score: " + score.ToString();
        timerText.text = "Timer: " + timer.ToString("F2");
    }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * (Time.deltaTime * moveSpeed));
        //}
        //if (Input.GetKey(KeyCode.D))
        //{

        //    transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
        //}
        //if (Input.GetKey(KeyCode.A)) 
        //{
        //    transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
        //}

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(Vector3.back * (Time.deltaTime * rotSpeed));
        //}
    }
