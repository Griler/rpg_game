using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy",menuName = "Enemy Template")]
public class EnemyTemplate : ScriptableObject
{
    public string name;

    public RuntimeAnimatorController animator;
    public Sprite sprite;
    
    public int attackDamge;
    public int maxHeath;
    public float speed;
}