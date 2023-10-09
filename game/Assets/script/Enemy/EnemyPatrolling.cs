using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public GameObject pointLeft;
    public GameObject pointRight;
    public Vector2 distane = new Vector2(3,0);
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {pointLeft.transform.position= this.transform.position
                                   * (Vector2.left* distane);
        pointRight.transform.position = this.transform.position
                                        *(Vector2.right* distane);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
