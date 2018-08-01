using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework
{
    class BaseUI : MonoBehaviour
    {
        NavigationData _NaviData = new NavigationData();
        public virtual NavigationData NaviData
        {
            get
            {
                return _NaviData;
            }
            protected set
            {
                _NaviData = value;
            }
        }

        public Action _OnOpen;
        public Action _OnClose;
        public Action _OnShow;
        public Action _OnHide;

        public virtual void Open(NavigationData data = null)
        {
            Show();
            if (_OnOpen != null)
            {
                _OnOpen();
            }

            if (data != null)
            {
                NaviData = data;
            }
        }

        public virtual void Close()
        {
            UIManager.Instance.Close(this);
        }

        internal void CloseInternal()
        {
            if (_OnClose != null)
            {
                _OnClose();
            }

            // 处理显示状态
            if (NaviData._CloseByDestroy)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Hide();
            }
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);

        }

        public virtual void Hide()
        {

            gameObject.SetActive(false);
        }
    }
}
