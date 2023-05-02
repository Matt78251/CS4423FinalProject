using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleEnemy : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Color color1;
    public Color color2;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor() 
    {
        while (true) 
        {
      
            if (sprite.color == color1)
                sprite.color = color2;
      
            else
                sprite.color = color1;

            yield return new WaitForSeconds(2);
        }
    }
}
