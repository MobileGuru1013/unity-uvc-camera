using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCameraWin : MonoBehaviour {

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN


	Texture2D texture;
	Renderer render;

	CvUVCControl cvuvc;

	float focus = 0;
	float contrast = 128;
	float brightness = 128;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer>();
		cvuvc = GetComponent<CvUVCControl>();

		cvuvc.UseCamera(1);

		texture = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
        render.material.mainTexture = texture;

	}



	// Update is called once per frame
	void Update () {

		if(cvuvc.IsGrab() && cvuvc.IsOpen()){
			texture.LoadRawTextureData(cvuvc.GetRawTetureData());
			texture.Apply();
		}

	}

	void OnGUI(){
		if(cvuvc.IsOpen()){
			focus = GUI.HorizontalSlider(new UnityEngine.Rect(20, 20, 240, 20), focus, 0f , 255f);
			GUI.Label(new UnityEngine.Rect(270, 15, 240,20), "Focus");

			contrast = GUI.HorizontalSlider(new UnityEngine.Rect(20, 50, 240, 20), contrast, 0f , 255f);
			GUI.Label(new UnityEngine.Rect(270, 45, 240,20), "Contrast");

			brightness = GUI.HorizontalSlider(new UnityEngine.Rect(20, 80, 240, 20), brightness, 0f , 255f);
			GUI.Label(new UnityEngine.Rect(270, 75, 240,20), "Brightness");


			cvuvc.Focus = focus;
			cvuvc.Contrast = contrast;
			cvuvc.Brightness = brightness;
		}
	}

#endif

}
