using System;
using System.Collections;
using System.Collections.Generic;
using Core.Singleton;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        RUN
    }
    public List<VFXManagerSetup> vfxSetup;

    public void PlayVfxByType(VFXType vfxType, Vector3 position)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 1f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}