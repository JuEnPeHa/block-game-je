using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public SCR_Level Level;

    public Vector2 startPosition;
    public bool offsetOddRow;
    public float distanceX = 2;
    public float offset = 1;
    public float distanceY = 1;
    

    private void OnDrawGizmos()
    {
        if (Level != null)
        {
            for (int i = 0; i < Level.gridSize.y; i++)
            {
                for (int j = 0; j < Level.gridSize.x; j++)
                {
                    float xDist = (i % 2 == 1 && offsetOddRow) ? j * distanceX + offset : j * distanceX;
                    Vector3 pos = new Vector3(startPosition.x + xDist, startPosition.y + i - distanceY);
                    Gizmos.DrawWireCube(pos, new Vector3(2,1,1));
                }
            }
        }
    }
}
