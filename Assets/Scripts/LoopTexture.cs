using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        float offset = (Time.time * scrollSpeed) % 1.0f;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
