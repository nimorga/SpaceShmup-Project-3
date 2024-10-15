using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    [Header("Enemy_2 Inscribed Fields")]
    public float lifeTime = 10;
    [Tooltip("Determines how much the Sine wave will eaase the interpolation")]
    public float sinEccentricity = 0.6f;
    [Header("Enemy_2 Private Fields")]
    [SerializeField] private float birthTime; //Interpolation start time
    [SerializeField] private Vector3 p0, p1; //Lerp_points
   
    void Start()
    {
        //Pick any point on left side on screen
        p0 = Vector3.zero;
        p0.x = -bndCheck.camWidth - bndCheck.radius;
        p0.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        //Pick any right side on screen
        p1 = Vector3.zero;
        p1.x = bndCheck.camWidth + bndCheck.radius;
        p1.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        //Possibly Swap Sides
        if(Random.value > 0.5f){
            //Will it move it to the opposite side of the screen bc set to its negative
            p0.x *= -1;
            p1.x *= -1;
        }
        //Set the birthTime to the current time
        birthTime = Time.time;
    }

    public override void Move(){
        //Linear interpolations work based on a u value between 0 & 1
        float u = (Time.time - birthTime) / lifeTime;

        //If u>1 then it has been longer than lifeTime since birthTime
        if(u > 1){
            //Enemy 2 has finished life
            Destroy(this.gameObject);
            return;
        }

        //Adjust u by adding a U curve on a sine wave
        u = u + sinEccentricity*(Mathf.Sin(u*Mathf.PI*2));

        //Interpolate the 2 linear interpolation points
        pos = (1-u)*p0 + u*p1;
    }
    
}
