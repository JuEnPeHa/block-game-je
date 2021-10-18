using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1;
    public int score = 50;
    
    void Start()
    {
        //ADD THE BRICK TO GAME MANAGER
        GameManager.instance.AddBrick(this.gameObject);
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            //CREATE PARTICLES
            
            
            //CREATE MUSIC
            
            
            //REPORT TO THE GAME MANAGER
            GameManager.instance.RemoveBrick(this.gameObject);
            
            
            //REPORT TO THE SCORE MANAGER
            ScoreManager.instance.Addscore(score);
            
            //DESTROY BRICK
            Destroy(gameObject);
            
        }
    }
}
