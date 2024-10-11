using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S {get; private set;} //Singleton property; automatic property

    [Header("Inscribed")]
    //Control movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Dynamic")][Range(0,4)]//Adds a slider of 0-4 in the Inspector
    public float shieldLevel = 1;


    void Awake(){
        if(S == null){
            S = this;//Set singleton is null
        }
        else{
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }


    void Update()
    {
        //Grabs user input
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //Change transform.pos base don the axes
        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        //Rotate the ship to make it feel more dynamic (a bit of rotation based on speed)
        transform.rotation = Quaternion.Euler(vAxis*pitchMult, hAxis*rollMult, 0);
    }
}
