using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveController : Controller
{
    void Move(Vector3 value);
}
