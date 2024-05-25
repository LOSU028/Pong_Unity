using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController1 : MonoBehaviour
{
    Camera maincamera;
    Vector2 blockposition;
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        blockposition = maincamera.WorldToScreenPoint(transform.position);
        Move();
    }
    void Move(){
        float moveDirection  = Input.GetAxis("Verticalp1") * moveSpeed * Time.deltaTime;
        transform.Translate(0,moveDirection,0);
    }

    void LateUpdate(){
        if(blockposition.y < 0){
            transform.Translate(0,0.1f,0);
        }else if(blockposition.y > maincamera.pixelHeight){
            Debug.Log("Afuera");
            transform.Translate(0,-0.01f,0);
        }
    }

}
