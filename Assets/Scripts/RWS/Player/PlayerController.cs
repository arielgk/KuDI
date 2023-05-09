using System;
using Example;
using KuDI;
using RWS.State;
using UnityEngine;

namespace RWS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [InjectField]
        private IAppState _appState = null;


        private void OnEnable()
        {
            Debug.Log(_appState.GetState().lives);
        }


        private void Update()
        {
           // eveery 10 seconds add a life to appstate 
        }
    }
}