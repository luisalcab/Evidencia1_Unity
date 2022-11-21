using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataManager : MonoBehaviour
{

    private Carro[] _listaDeCarros;
    private GameObject[] _carrosGO;

    void Start()
    {
        _listaDeCarros = new Carro[CarPoolManager.Instance._tamanioPool];

        for (int i = 0; i < _listaDeCarros.Length; i++)
        {
            _listaDeCarros[i] = new Carro();
            _listaDeCarros[i].id = 0;
            _listaDeCarros[i].x = 0;
            _listaDeCarros[i].y = 0;
            _listaDeCarros[i].z = 0;
        }

        _carrosGO = new GameObject[_listaDeCarros.Length];

        for(int i = 0; i < _listaDeCarros.Length; i++)
        {
            _carrosGO[i] = CarPoolManager.Instance.Activar(Vector3.zero);
        }
    }

    private void PosicionarCarros() {
        // activar los 10 carritos en las posiciones congruentes
        for(int i = 0; i < _listaDeCarros.Length; i++) 
        {
            _carrosGO[i].transform.position = new Vector3(
                _listaDeCarros[i].x,
                _listaDeCarros[i].y,
                _listaDeCarros[i].z
            );
        }
    }

    public void EscucharPosiciones(ListaCarro datos) {

        for (int i = 0; i < datos.carros.Length; i++)
        {
            _listaDeCarros[i].x = datos.carros[i].x;
            _listaDeCarros[i].y = datos.carros[i].y;
            _listaDeCarros[i].z = datos.carros[i].z;
        }

        PosicionarCarros();
    }
}
