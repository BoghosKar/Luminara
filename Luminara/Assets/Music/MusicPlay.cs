using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    
public static MusicPlay musicplay;
	public bool Always;
	public GameObject music;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
		if (MusicPlay.musicplay == null)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			MusicPlay.musicplay = this;
			return;
		}
		if (MusicPlay.musicplay != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
