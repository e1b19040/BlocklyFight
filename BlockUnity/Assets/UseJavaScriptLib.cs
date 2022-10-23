using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
 
public class UseJavaScriptLib : MonoBehaviour
{
	[DllImport("__Internal")]
	private static extern void MyTestFunction();
	[DllImport("__Internal")]
	private static extern void SyncFile();
 
	// Start is called before the first frame update
	void Start()
    {
		MyTestFunction();
		SyncFile();
	}
}