using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectablePlanet : ItemCollectableBase
{
  protected override void OnCollect()
  {
    base.OnCollect();
    ItemManager.Instance.AddPlanets();
  }
}