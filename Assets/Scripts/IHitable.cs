using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
    void GetHit(int damageValue, GameObject sender);
}
