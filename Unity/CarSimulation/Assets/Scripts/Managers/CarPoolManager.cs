using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPoolManager : MonoBehaviour
{

    public static CarPoolManager Instance {
        get;
        private set;
    }

    [SerializeField]
    private GameObject _carritoOriginal;

    [SerializeField]
    public int _tamanioPool;
    private Queue<GameObject> _pool;

    void Awake() {

        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if(_carritoOriginal == null){
            throw new System.Exception("CAR POOL MANAGER: ES NECESARIO UN CARRO");
        }

        _pool = new Queue<GameObject>();

        // creamos objetos y agregamos al pool
        for(int i = 0; i < _tamanioPool; i++){

            // método para crear objetos
            GameObject actual = Instantiate<GameObject>(_carritoOriginal);
            actual.SetActive(false);
            _pool.Enqueue(actual);
        }
    }


    public GameObject Activar(Vector3 posicion) {

        // evitamos error - no hay objetos en pool
        if(_pool.Count == 0){
            Debug.LogError("TE QUEDASTE SIN OBJETOS");
            return null;
        }

        // obtengo objeto de pool
        GameObject actual = _pool.Dequeue();

        actual.SetActive(true);
        actual.transform.position = posicion;
        
        return actual;
    }

    public void Desactivar(GameObject objetoADesactivar){

        objetoADesactivar.SetActive(false);
        _pool.Enqueue(objetoADesactivar);
    }
}
