using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRenderTexture : MonoBehaviour {
	public Camera camera;
	public RenderTexture rt;
	// Use this for initialization
	void Start () {
		
		/*int resWidth = 256;
		int resHeight = 256;

		rt = new RenderTexture (resWidth,resHeight,24);
		camera.targetTexture = rt;
		Texture2D screenShot = new Texture2D (resWidth, resHeight, TextureFormat.ARGB32, false);
		camera.Render ();
		RenderTexture.active = rt;
		screenShot.ReadPixels (new Rect(0,0,resWidth,resHeight),0,0);
		camera.targetTexture = null;
		RenderTexture.active = null;
		Destroy (rt);*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
