using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyIn : MonoBehaviour


{

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator AnimateFly(float duration)
    {
       
        yield return new WaitForSeconds(duration);
    }

    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();

        //print(transform.position.x);
        
        //StartCoroutine(AnimateFly(0.00f));

    }
}
