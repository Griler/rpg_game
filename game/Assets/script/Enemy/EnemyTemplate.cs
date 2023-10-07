using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy",menuName = "Enemy Template")]
public class EnemyTemplate : ScriptableObject
{
    public string name;

    public AnimatorController animator;
    public Sprite sprite;
    
    public int attackDamge;
    public int maxHeath = 100;
    
}