using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallController : MonoBehaviour
{

    [SerializeField] float timeToReload; 

    Scores scores_script;
    [SerializeField] GameObject scores;

    public Camera maincamera;
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector3 lastvelocity;
    Vector2 initialDirection;
    float ballSpeed = 5f;
    int direction = 1;
    Vector2 ballposition;
    public Vector2 screenBallPosition;
    //numbers here are taken from the position in the editor in the transform component
    Vector2 initialPosition = new Vector2(1.75f, 3.37f); 
    void Awake(){
        scores_script = scores.GetComponent<Scores>();
    }
    
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();  
        maincamera = Camera.main;
        initialDirection = new Vector2 (direction,-1f);
        rb.velocity = initialDirection * ballSpeed;
            
    }
    void Update()
    {
         
        
        ballposition = transform.position;
        lastvelocity = rb.velocity;
        screenBallPosition =  maincamera.WorldToScreenPoint(transform.position);
        Vector2 rightEdge = maincamera.ScreenToWorldPoint(new Vector2(Screen.width,0));
        checkIsInside();

    }


    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "wall" || other.gameObject.tag == "Player"){
            float speed = lastvelocity.magnitude;
            var direction =  Vector3.Reflect(lastvelocity.normalized, other.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }
    void checkIsInside(){
        if(screenBallPosition.x < 0 || screenBallPosition.x > maincamera.pixelWidth){
            Invoke("ResetPosition",timeToReload);
            direction = -direction;
            initialDirection = new Vector2 (direction,-1f);
        }
    }

    void ResetPosition(){
        transform.position = initialPosition;
        rb.velocity = initialDirection * ballSpeed;
        scores_script.hasexited = !scores_script.hasexited;
    }
}
