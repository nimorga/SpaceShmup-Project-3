using System.Collections;           // Required for some Arrays manipulation
using System.Collections.Generic;   // Required for Lists and Dictionaries
using UnityEngine;                  // Reuqired for Unity

[RequireComponent(typeof(BoundsCheck) )]
public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed      = 10f;      // The movement speed is 10 m/s
    public float firerate   = 0.3f;      // Seconds/shot (Unused)
    public float health     = 10;       // Damage needed to destroy this enemy
    public int score        = 100;      // Points earned for destroying this

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // This is a Property: A method that acts like a field
    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();

        // Check whether this Enemy has gone off the bottom of the screen
        if (bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown))
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision coll){ //Get gameobject within the collision
        GameObject otherGO = coll.gameObject;
        if(otherGO.GetComponent<ProjectileHero>() != null){
            Destroy(otherGO); //Destory Projectile
            Destroy(gameObject); //Destory this enemy GameObject
        }
        else{
            Debug.Log("Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }
}
