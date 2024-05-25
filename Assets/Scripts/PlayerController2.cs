using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        float moveDirection  = Input.GetAxis("Verticalp2") * moveSpeed * Time.deltaTime;
        transform.Translate(0,moveDirection,0);
    }

}
