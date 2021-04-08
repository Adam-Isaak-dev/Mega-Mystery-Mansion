using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is for a scrolling background using quads.
//THIS IS NOT FOR PARALAX, WHICH HAS MULTIPLE LAYERS AND MOVES W/CAMERA.
//This is a single layer that remains static

public class OneScroll : MonoBehaviour
{

    public float scrollSpeed;
    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
