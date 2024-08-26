using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt sOInt;
    public TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = sOInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = sOInt.value.ToString();
    }
}
