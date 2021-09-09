using System;
using NaughtyAttributes;

using UnityEngine;

public class UIBackButton : MonoBehaviour {
	private static UIBackButton instance;
	[ShowNonSerializedField] private bool canGoBack = true;
	public static bool CanGoBack {
		get => instance.canGoBack;
		set => instance.canGoBack = value;
	}
	public static event Action GoingBack;

	private void Awake() {
		if(instance != null)
			Destroy(this);
		
		instance = this;
	}
	
	public static void GoBack() {
		if (instance.canGoBack) 
			GoingBack?.Invoke();
	}
}