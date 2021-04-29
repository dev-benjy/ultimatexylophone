using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenApp : MonoBehaviour
{
    public float smoothness;
    public Image loadimage;
    AsyncOperation asyncload;

    void Start()
    {
        StartCoroutine(SLoad());
    }
    IEnumerator SLoad()
    {
        loadimage.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        asyncload = SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
        asyncload.allowSceneActivation = false;

    }
    float currentValue;
    float targetvalue;
    private void Update()
    {
        targetvalue = asyncload.progress / 0.9f;
        currentValue = Mathf.MoveTowards(currentValue, targetvalue, smoothness * Time.deltaTime);
        loadimage.fillAmount = currentValue;
        if(Mathf.Approximately(currentValue,1))
        {
            asyncload.allowSceneActivation = true; ;
        }
    }
}
