using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public GameObject leftWall, rightWall, topWall, bottomWall;
    public GameObject lCorner, rCorner;
    
    private float distanceToCamera;
    private Vector3 screenBoundaries;
    private Vector3 screenPoint;

    private Vector3 cameraPos;
    
    private void Start()
    {
        distanceToCamera = Camera.main.transform.position.z;
        CalculateBoundaries();
    }

    void CalculateBoundaries()
    {
        
        cameraPos = Camera.main.transform.position;
        float frustrumHeight = 2.0f * distanceToCamera * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustrumWidth = frustrumHeight * Camera.main.aspect;
        screenBoundaries = new Vector3(frustrumWidth, frustrumHeight, 0);
        screenPoint = new Vector3(cameraPos.x, cameraPos.y, 0);

        //LEFT WALL
        Vector3 leftPoint = new Vector3(
            cameraPos.x - Mathf.Abs(frustrumWidth) / 2,
            cameraPos.y, 0);
        leftWall.transform.position = leftPoint;
        leftWall.transform.localScale = new Vector3(1, Mathf.Abs((screenBoundaries.y)), 1);

        //RIGHT WALL
        Vector3 rightPoint = new Vector3(
            cameraPos.x + Mathf.Abs(frustrumWidth) / 2,
            cameraPos.y, 0);
        rightWall.transform.position = rightPoint;
        rightWall.transform.localScale = new Vector3(1, Mathf.Abs((screenBoundaries.y)), 1);
        
        
        
        //TOP WALL
        Vector3 topPoint = new Vector3(
            cameraPos.x,
            cameraPos.y + Mathf.Abs(frustrumHeight / 2), 0);
        topWall.transform.position = topPoint;
        topWall.transform.localScale = new Vector3( Mathf.Abs((screenBoundaries.x)),1, 1);

        
        
        //BOTTOM WALL
        Vector3 bottomPoint = new Vector3(
            cameraPos.x,
            cameraPos.y - Mathf.Abs(frustrumHeight / 1.8f), 0);
        bottomWall.transform.position = bottomPoint;
        bottomWall.transform.localScale = new Vector3( Mathf.Abs((screenBoundaries.x)),1, 1);
        
        //R CORNER
        rCorner.transform.position = new Vector3(rightPoint.x, topPoint.y, 0);
        
        //L CORNER
        lCorner.transform.position = new Vector3(leftPoint.x, topPoint.y, 0);
    }
}