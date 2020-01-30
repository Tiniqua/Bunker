using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    private float xOffset = 0;
    private Material mat;
    //public GameObject Fog;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        xOffset += Time.deltaTime*.1f;
        mat.SetTextureOffset("_MainTex", new Vector2(xOffset, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);   
        }
    }
}
