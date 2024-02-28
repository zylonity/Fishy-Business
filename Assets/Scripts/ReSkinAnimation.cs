using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSkinAnimation : MonoBehaviour
{
    public string spriteSheetName;

    private Sprite[] subSprites;

    void Start(){
        subSprites = Resources.LoadAll<Sprite>("Fish/" + spriteSheetName);
    }

    void LateUpdate()
    {

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
            {
                renderer.sprite = newSprite;
            }
        }
    }
}
