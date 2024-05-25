using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    
    int ScorePLayer1 = 0;
    int ScorePLayer2 = 0;

    public bool hasexited = false;

    BallController ballcontroller;
    [SerializeField] GameObject ball;
    
    [SerializeField] Text ScorePlayer1_Text;
    [SerializeField] Text ScorePlayer2_Text;
    
    void Awake(){
        ballcontroller = ball.GetComponent<BallController>(); 
    }
    void Update()
    {
        UpdateScores();
        UpdateScoresText();
        
        //Debug.Log(ballcontroller.screenBallPosition.x);
    }

    void UpdateScores(){
        //if ball exits left then player 2 gets a point
        if(ballcontroller.screenBallPosition.x < 0 && !hasexited){
            ScorePLayer2 += 1;
            hasexited = !hasexited;
        }
        if(ballcontroller.screenBallPosition.x > ballcontroller.maincamera.pixelWidth && !hasexited){ //if ball exits right then player 1 gets a point
            ScorePLayer1 += 1;
            hasexited = !hasexited;
        }
    }

    void UpdateScoresText(){
        ScorePlayer1_Text.text = ScorePLayer1 > 9 ? ScorePLayer1.ToString("00") : ScorePLayer1.ToString();
        ScorePlayer2_Text.text = ScorePLayer2 > 9 ? ScorePLayer2.ToString("00") : ScorePLayer2.ToString();
    }
}
