using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an enum of the various possible weapon types.
/// It also inclues a "shield" type to allow a shield PowerUp.
/// Items marked [NI] below are Not Implemented in this book.
/// </summary>
public enum eWeaponType
{
    none,       // The default / no weapon
    blaster,    // A simple blaster
    spread,     // Mutiple shots simultanesouly
    phaser,     // [NI] Shots that move in waves
    missle,     // [NI] Homing missiles
    laser,      // [NI] Damage over time
    shield      // Raise shieldLevel  
}

/// <summary>
/// The WeaponDefinition class allows you to set the properties
///   of a specific weapon in the Inspector. The main class has
///   an array of WeaponDefinitions that makes this possible.
/// </summary>
[System.Serializable]
public class WeaponDefinition
{
    public eWeaponType type = eWeaponType.none;
    [Tooltip("Letter to show on the PowerUp Cube")]
    public string letter;
    [Tooltip("Color of PowerUp Cube")]
    public Color powerUpColor = Color.white;
    [Tooltip("Prefab of Weapon model that is attached to the Player Ship")]
    public GameObject weaponModelPrefab;
    [Tooltip("Prefab of projectile that is fired")]
    public GameObject projectilePrefab;
    [Tooltip("Color of the Projectile that is fired")]
    public Color projectileColor = Color.white;
    [Tooltip("Damage caused when a single Projectile hits an Enemy")]
    public float damageOnHit = 0;
    [Tooltip("Damage caused per second by the Laser [Not Implemented]")]
    public float damagePerSec = 0;
    [Tooltip("Seconds to delay between shots")]
    public float delayBetweenShots = 0;
    [Tooltip("Velocity of individual Projectiles")]
    public float velocity = 50;
}

public class Weapon : MonoBehaviour 
{
    // For now, please delete everything insdie the Weapon class definition.
}
