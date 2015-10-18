using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour
	where T : Singleton<T>
{
	public static T instance;
	
	protected void Awake ()
	{
		if (instance == null) {
			instance = this as T;
		} else {
			Debug.LogError ("Trying to instantiate multiple instances of " + this.GetType ().ToString ());
		}
	}
	
	public static GameObject Get ()
	{
		return instance.gameObject;
	}
}
