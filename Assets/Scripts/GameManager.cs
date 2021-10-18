using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;

    private List<GameObject> ballList = new List<GameObject>();
    private List<GameObject> brickList = new List<GameObject>();

    private int lifes;
    public Text lifesText;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        lifes = 3;
        CreateBall();
        //UPDATE UI
        UpdateUILife();
    }

    //------------------------LIFES--------------------------

    void UpdateUILife()
    {
        lifesText.text = "Lifes: " + lifes.ToString("D2");
    }
    
    void RemoveLife()
    {
        lifes--;
        //UPDATE UI
        UpdateUILife();
        //LOSE CONDITION
        if (lifes == 0)
        {
            print("GAME OVER");
            return;
        }
        
        CreateBall();
        //RESET PADDLE POSITION
        Paddle.instance.ResetPaddle();
    }

    public void LostBall(GameObject ball)
    {
        ballList.Remove(ball);
        Destroy(ball);

        if (ballList.Count == 0)
        {
            RemoveLife();
        }
    }
    

    //------------------------BRICKS--------------------------

    public void AddBrick(GameObject brick)
    {
        brickList.Add(brick);
    }

    public void RemoveBrick(GameObject brick)
    {
        brickList.Remove(brick);
        //WINNING CONDITION
        if (brickList.Count == 0)
        {
            print("You Won");
        }
    }
    
    
    //------------------------CREATE--------------------------

    void CreateBall()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = Paddle.instance.gameObject.transform.position + new Vector3(0, 1.5f, 0);
        newBall.transform.SetParent(Paddle.instance.gameObject.transform);
        newBall.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        
        ballList.Add(newBall);
    }

    void StartBall()
    {
        ballList[0].GetComponent<Ball>().StartBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ballList.Count>0)
        {
            Debug.Log("Lanzando bola");
            if (ballList[0] != null && !ballList[0].GetComponent<Ball>().BallStarted())
            {
                StartBall();

            }
        }
    }
}
