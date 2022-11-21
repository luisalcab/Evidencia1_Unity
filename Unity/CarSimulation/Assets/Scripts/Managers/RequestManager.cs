using System.Diagnostics;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;
using UnityEngine.Events;
using System;

[Serializable]
public class RequestPositions : UnityEvent<ListaCarro> {}

public class RequestManager : MonoBehaviour
{

    [SerializeField]
    private RequestPositions _requestPositions;
    private IEnumerator _enumeratorCorrutina;
    private Coroutine _corrutina;
    [SerializeField]
    private string _url = "http://127.0.0.1:5000/get_positions";

    void Start(){
        _enumeratorCorrutina = Request(); 
        _corrutina = StartCoroutine(_enumeratorCorrutina);
    }

    void Update() {
    }

    IEnumerator Request() {
        while(true)
        {
            UnityWebRequest www = UnityWebRequest.Get(_url + "/" + CarPoolManager.Instance._tamanioPool);

            // Este asunto es asíncrono
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success){
                Debug.LogError(www.error);
            } else {

                // hacer parisng de JSON
                ListaCarro listaCarro = JsonUtility.FromJson<ListaCarro>(
                    www.downloadHandler.text
                );

                _requestPositions.Invoke(listaCarro);
            }

            yield return new WaitForSeconds(1);
        }
    }
}