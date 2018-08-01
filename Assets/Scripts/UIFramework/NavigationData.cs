using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework
{
    enum EUILayer
    {
        FullScreen = 0,
        Popup = 100,
        Tips = 200,
    }

    enum EUIType
    {
        FullScreen,
        Resident,
        Coexisting,
        Independent
    }

    class NavigationData
    {
        public EUILayer _Layer;
        public uint _Group;
        public List<object> _UIParams = new List<object>();
        public bool _CloseByDestroy; 
        public bool _IsJumpBack; // 向回跳转，弹出之后的所有UI
        public EUIType _Type; 
    }
}
