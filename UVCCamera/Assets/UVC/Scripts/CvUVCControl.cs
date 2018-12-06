using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using OpenCvSharp;
#endif

public class CvUVCControl : MonoBehaviour {

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN

	VideoCapture vc;

	int width;
    int height;
    int frameRate;
	bool isOpened = false;

	byte[] result;
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
	public void UseCamera(int idx, int h = 1080, int w = 1920, int fps = 30){
		vc = new VideoCapture(idx);	
		isOpened = vc.IsOpened();

		if(!isOpened) {
			Debug.Log("Error : Camera device not open.");
			return;
		}

		height = h;
		width = w;
		frameRate = fps;

		vc.FrameHeight = height;
		vc.FrameWidth = width;
	}

	public void ReleaseCamera(){
		isOpened = false;
		vc.Release();
		vc.Dispose();
	}

	public byte[] GetRawTetureData(){

		Mat image = vc.RetrieveMat();
		Mat cvtImage = image.CvtColor(ColorConversionCodes.BGR2RGB);
		result = cvtImage.ImEncode(".bmp");

		return result;
	}

	public bool IsGrab(){
		return vc.Grab();
	}

	public bool IsOpen(){
		return isOpened;		
	}

	public double AutoExposure{
		get{return vc.AutoExposure;}
		set{vc.AutoExposure = value;}
	}

	public bool AutoFocus{
		get{return vc.AutoFocus;}
		set{vc.AutoFocus = value;}
	}

	public double Exposure{
		get{return vc.Exposure;}
		set{vc.Exposure = value;}
	}

	public double Focus{
		get{return vc.Focus;}
		set{vc.Focus = value;}
	}
	public double Gain{
		get{return vc.Gain;}
		set{vc.Gain = value;}
	}

	public double Brightness{
		get{return vc.Brightness;}
		set{vc.Brightness = value;}
	}

	public double Contrast{
		get{return vc.Contrast;}
		set{vc.Contrast = value;}
	}

	public double Saturation{
		get{return vc.Saturation;}
		set{vc.Saturation = value;}
	}
		
	public double Sharpness{
		get{return vc.Sharpness;}
		set{vc.Sharpness = value;}
	}

	public double Hue{
		get{return vc.Hue;}
		set{vc.Hue = value;}
	}

	public double WhiteBalanceRed{
		get{return vc.WhiteBalanceRedV;}
		set{vc.WhiteBalanceRedV = value;}
	}
	public double WhiteBalanceBlue{
		get{return vc.WhiteBalanceBlueU;}
		set{vc.WhiteBalanceBlueU = value;}
	}

	public double Zoom{
		get{return vc.Zoom;}
		set{vc.Zoom = value;}
	}


	void OnDestroy(){
		if(isOpened){
			vc.Release();
			vc.Dispose();
		}
	}
#endif
}
