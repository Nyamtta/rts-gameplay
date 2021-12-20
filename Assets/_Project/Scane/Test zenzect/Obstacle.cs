using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour , IObstacle
{
    public void IsCollision()
    {
        Debug.Log(gameObject.name); 
    }
}
