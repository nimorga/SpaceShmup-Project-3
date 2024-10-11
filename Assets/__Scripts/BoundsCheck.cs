using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public enum eType {center, inset, outset};//Allows us to control whether the BoundsCheck is centered,inset, or outset

    [Header("Inscribed")]
    public eType boundsType = eType.center;//is set to 0
    public float radius = 1f;

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    void Awake(){
        camHeight = Camera.main.orthographicSize;//Camera.main gives access to first camera; ortho gives you the size number from Camera inspector
        camWidth = camHeight * Camera.main.aspect;//aspect ratio (gets the distance from the orgion to the left or right edge of the screen)
    }

    void LateUpdate(){ //Called every fram after update

        float checkRadius = 0;
        if(boundsType == eType.inset) checkRadius = -radius; //set -radius shrinking the size of the screen bounds by radius
        if(boundsType == eType.outset) checkRadius = radius; //set positive radius expanding the size of the screen bounds

        Vector3 pos = transform.position;

        //Restrict x pos to camWidth
        if(pos.x > camWidth + checkRadius){
            pos.x = camWidth + checkRadius;
        }

        if(pos.x < -camWidth - checkRadius){
            pos.x = -camWidth - checkRadius;
        }

        //Restrict y pos to camHeight
        if(pos.y > camHeight + checkRadius){
            pos.y = camHeight + checkRadius;
        }

        if(pos.y < -camHeight - checkRadius){
            pos.y = -camHeight - checkRadius;
        }

        transform.position = pos;
    }
}
