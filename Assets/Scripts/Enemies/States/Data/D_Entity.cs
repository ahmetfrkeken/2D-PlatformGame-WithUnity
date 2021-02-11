using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName ="Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{//Entity ile ilgili tüm verilerin bulunduğu script.
    public float wallCheckDistance;
    public float ledgeCheckDistance;

    public LayerMask whatIsGround;
}
