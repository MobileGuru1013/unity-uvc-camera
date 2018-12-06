using UnityEngine;
using System.Collections;

public class WebCameraOSX : MonoBehaviour {

#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX

    UVCControl cameraControl;
    private WebCamTexture webcamtex;

    float focus;
    float contrast;

    void Awake(){  
    }

    // Use this for initialization
    void Start(){

        cameraControl = new UVCControl();
        cameraControl.UseCameraLocate(0x14200000);

        cameraControl.AutoFocus = false;
        focus = cameraControl.AbsoluteFocus;
        contrast = cameraControl.Contrast;

        WebCamDevice[] devices = WebCamTexture.devices;
        foreach (WebCamDevice device in devices){
            Debug.Log("WebCamDevice " + device.name);
        }

        webcamtex = new WebCamTexture(devices[1].name); 
        
        Renderer _renderer = GetComponent<Renderer>();
        _renderer.material.mainTexture = webcamtex;
        webcamtex.Play();
    }

    void OnGUI(){
	 	GUI.Label(new UnityEngine.Rect(270, 15, 240, 20), "Focus");
	 	focus = GUI.HorizontalSlider(new UnityEngine.Rect(20, 20, 240, 20), focus, 0f, 1f);
	 	GUI.Label(new UnityEngine.Rect(270, 45, 240, 20), "Contrast");
	 	contrast = GUI.HorizontalSlider(new UnityEngine.Rect(20, 50, 240, 20), contrast, 0f, 1f);
 
        cameraControl.Contrast = contrast;
        cameraControl.AbsoluteFocus = focus;
	}

 #endif

}