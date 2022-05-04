using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public Sprite[] sides;
    int flipCount = 1;
    float originalSize;
   

    private void OnMouseDown()
    {
        StartCoroutine(WaitPlease(0.00000000000001f, originalSize));
      
    }

    IEnumerator WaitPlease(float duration, float size)
    {
        while (size > 0.1)
        {
            size = size - 0.2f;
            transform.localScale = new Vector3(size, originalSize, 1);
            yield return new WaitForSeconds(duration);
        }
        spriteRenderer.sprite = sides[flipCount % 2];
        while(size < originalSize)
        {
            size = size + 0.2f;
            transform.localScale = new Vector3(size, originalSize, 1);
            yield return new WaitForSeconds(duration);
        }
        flipCount++;
    }

    IEnumerator ShowCard(float duration, float opacity, float yPos, float originalSize)
    {
        float moveDown= yPos + 2f;
        float shrinkDown = 0.8f;
        while (opacity < 1f || moveDown < yPos || shrinkDown > originalSize)
        {
            if(opacity < 1f)
            {
                opacity = opacity + 0.02f;
                spriteRenderer.color = new Color(1f, 1f, 1f, opacity);
            }

            if(moveDown > yPos)
            {
                moveDown = moveDown - 0.2f;
                transform.position = new Vector3(-6.5f, moveDown, 0);  
            }

            if(shrinkDown > originalSize) 
            {
                shrinkDown = shrinkDown - 0.15f;
                transform.localScale = new Vector3(shrinkDown, shrinkDown, shrinkDown);
            }

            yield return new WaitForSeconds(duration);
        }
      
    }

    private void Awake()
    {

        originalSize = transform.localScale.x;
        print(originalSize);
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ShowCard(0.00005f, 0f, transform.position.y, originalSize));


    } 
}
