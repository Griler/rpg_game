using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.InstantiateOject();
    }
}