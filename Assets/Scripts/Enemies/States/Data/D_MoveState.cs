using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
public class D_MoveState : ScriptableObject //ScriptableObject bir data containerıdır(veri saklayıcısı) yüksek miktardaki
//verileri saklamaya yarar, class yapısından bağımsız olarak, tüm hareket ile ilgili değişkenlerimi ve verilerimi burada sakladım
{
    public float movementSpeed = 3f;
}
