using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLauncher : MonoBehaviour
{
    public Type[] GetChildTypes(Type parentType)
    {
        List<Type> lstType = new List<Type>();
        System.Reflection.Assembly assem = System.Reflection.Assembly.GetAssembly(parentType);
        foreach (Type tChild in assem.GetTypes())
        {
            if (tChild.BaseType == parentType)
            {
                lstType.Add(tChild);
            }
        }
        return lstType.ToArray();
    }

    public void Export<T1, T2>()
    {

    }
    public void ExportByClassName(string typename1, string typename2)
    {
        Type t1 = Type.GetType(typename1);
        Type t2 = Type.GetType(typename2);
        System.Reflection.MethodInfo mi = this.GetType().GetMethod("Export").MakeGenericMethod(new Type[] { t1, t2 });
        mi.Invoke(this, null);
    }
}
