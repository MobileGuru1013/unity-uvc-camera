using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class UVCControl : MonoBehaviour {

	#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX

	[DllImport("UVCController")] private static extern bool useCamera(int vId, int pId, int num);
	[DllImport("UVCController")] private static extern bool useCameraLocate(uint lId);

	[DllImport("UVCController")] private static extern void setAutoExposure(bool val);
	[DllImport("UVCController")] private static extern bool getAutoExposure();

	[DllImport("UVCController")] private static extern void setAutoFocus(bool val);
	[DllImport("UVCController")] private static extern bool getAutoFocus();

	[DllImport("UVCController")] private static extern void setAutoWhiteBalance(bool val);
	[DllImport("UVCController")] private static extern bool getAutoWhiteBalance();

	[DllImport("UVCController")] private static extern void setExposure(float val);
	[DllImport("UVCController")] private static extern float getExposure();

	[DllImport("UVCController")] private static extern void setAbsoluteFocus(float val);
	[DllImport("UVCController")] private static extern float getAbsoluteFocus();

	[DllImport("UVCController")] private static extern void setWhiteBalance(float val);
	[DllImport("UVCController")] private static extern float getWhiteBalance();

	[DllImport("UVCController")] private static extern void setGain(float val);
	[DllImport("UVCController")] private static extern float getGain();
	
	[DllImport("UVCController")] private static extern void setBrightness(float val);
	[DllImport("UVCController")] private static extern float getBrightness();

	[DllImport("UVCController")] private static extern void setContrast(float val);
	[DllImport("UVCController")] private static extern float getContrast();

	[DllImport("UVCController")] private static extern void setSaturation(float val);
	[DllImport("UVCController")] private static extern float getSaturation();

	[DllImport("UVCController")] private static extern void setSharpness(float val);
	[DllImport("UVCController")] private static extern float getSharpness();


	public bool UseCamera(int vendorId, int productId, int interfaceNum){
		return useCamera(vendorId, productId, interfaceNum);
	}
	public bool UseCameraLocate(uint locateID){
		return useCameraLocate(locateID);
	}

	public bool AutoExposure{
		get {return getAutoExposure();}
		set {setAutoExposure(value);}
	}

	public bool AutoFocus{
		get {return getAutoFocus();}
		set {setAutoFocus(value);}
	}

	public bool AutoWhiteBalance{
		get {return getAutoWhiteBalance();}
		set {setAutoWhiteBalance(value);}
	}

	public float Exposure{
		get {return getExposure();}
		set {setExposure(value);}
	}

	public float AbsoluteFocus{
		get {return getAbsoluteFocus();}
		set {setAbsoluteFocus(value);}
	}

	public float WhiteBalance{
		get {return getWhiteBalance();}
		set {setWhiteBalance(value);}
	}

	public float Gain{
		get {return getGain();}
		set {setGain(value);}
	}


	public float Brightness{
		get {return getBrightness();}
		set {setBrightness(value);}
	}

	public float Contrast{
		get {return getContrast();}
		set {setContrast(value);}
	}

	public float Saturation{
		get {return getSaturation();}
		set {setSaturation(value);}
	}

	public float Sharpness{
		get {return getSharpness();}
		set {setSharpness(value);}
	}

#endif

}
