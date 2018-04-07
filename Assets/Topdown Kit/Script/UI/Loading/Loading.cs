using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

struct A {
    public int a;
    public int b;
}

public class Loading : MonoBehaviour {

    private UISlider progressBar;
    //private UILabel presentLabel;
    private float target = 0;
    private string _sceneName;
    // 异步对象
    AsyncOperation op = null;

    public Loading(string sceneName ) {
        this._sceneName = sceneName;
    }


    private void Awake() {
        progressBar = GameObject.Find( "ProgressBar" ).GetComponent<UISlider>();
        //presentLabel = GameObject.Find( "ProgressBar/Label" ).GetComponent<UILabel>();
    }

    // Use this for initialization
    void Start () {
        Debug.Log( "开始LoadScene" );

        op = SceneManager.LoadSceneAsync( Global.SceneName );
        op.allowSceneActivation = false;

        progressBar.value = 0;
        // 开启协程，开始调用加载方法；
        StartCoroutine( ProcessLoading() );
	}


    //public static event SceneLoaded SceneLoaded;
    float dtimer = 0;
	void Update () {
        progressBar.value = Mathf.Lerp( progressBar.value, target, dtimer * 0.02f );
        
        //presentLabel.text = Mathf.Ceil(progressBar.value * 100) + "%";
        dtimer += Time.deltaTime;
        if(progressBar.value > 0.99f ) {
            progressBar.value = 1;
            //presentLabel.text = Mathf.Ceil( progressBar.value * 100 ) + "%";
            op.allowSceneActivation = true;
            

            Dispatcher.DispatchEvent( EventName.SceneLoaded, Global.SceneName );
            Destroy( gameObject );
        }
	}

    
    IEnumerator ProcessLoading() {
        while ( true ) {
            target = op.progress; // 进度条取值范围0 - 1
            if(target >= 0.9f ) {
                target = 1;
                yield break;
            }
            yield return 0;
        }
    }
}
