using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public Image fade;

	public void PlayButton()
    {
        fade.gameObject.SetActive(true);
    }
}
