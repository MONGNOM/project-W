using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JellyPrefab : MonoBehaviour
{
    public JellyData jellyData; 

    private void Start()
    {
        //prefab = jellyData.JellyPrefab;

    }
    // Start is called before the first frame update

    public void SpawnPrefab()
    {
        
        Instantiate(jellyData.JellyPrefab);
    }



}
