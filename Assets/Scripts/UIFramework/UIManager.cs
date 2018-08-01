using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIFramework
{
    class UIManager
    {
        static UIManager _Instance;
        public static UIManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UIManager();
                }
                return _Instance;
            }
        }

        // 所有UI的对象池
        Dictionary<Type, Queue<BaseUI>> _UIPool = new Dictionary<Type, Queue<BaseUI>>();

        // 常驻UI例如返回键，金币，好友按钮
        List<BaseUI> _ResidentUI = new List<BaseUI>();

        // 已经打开的全屏界面
        // List作为栈，但也可从中间删除
        List<BaseUI> _OpenedFullScreenUI = new List<BaseUI>();

        // 共存的UI，例如物品详情Tips，弹窗等
        // List作为栈，但也可从中间删除
        Dictionary<BaseUI, List<BaseUI>> _CoexistingUI = new Dictionary<BaseUI, List<BaseUI>>();

        // 独立的UI，例如滚屏Tips，网络请求或加载中等
        List<BaseUI> _IndependentUI = new List<BaseUI>();

        public BaseUI CurFullScreenUI
        {
            get
            {
                if (_OpenedFullScreenUI.Count == 0)
                {
                    return null;
                }
                return _OpenedFullScreenUI[_OpenedFullScreenUI.Count - 1];
            }
        }

        // 几种特殊情况
        // 连续几个弹窗依次出现
        // 同时出现两个弹窗
        // 

        public T Get<T>()
            where T : BaseUI
        {
            var t = typeof(T);
            Debug.Log("Get t=" + t);
            if (_UIPool.ContainsKey(t))
            {
                var dict = _UIPool[t];
                if (dict.Count > 0)
                {
                    return dict.Dequeue() as T;
                }
                else
                {
                    // TODO 使用csv读取UI路径
                    return GameObject.Instantiate(Resources.Load<T>("UI/" + typeof(T).ToString()));
                }
            }
            return GameObject.Instantiate(Resources.Load<T>("UI/" + typeof(T).ToString()));
        }

        public void Push<T>(T ui)
            where T : BaseUI
        {
            var t = typeof(T);
            Debug.Log("Push t=" + t);
            if (!_UIPool.ContainsKey(t))
            {
                _UIPool[t] = new Queue<BaseUI>();
            }
            _UIPool[t].Enqueue(ui);
        }

        public T Open<T>(NavigationData data = null)
            where T : BaseUI
        {
            Debug.Log("Open t=" + typeof(T));
            var ui = Get<T>();
            if (ui == null)
            {
                Debug.LogError("get ui failed! t=" + typeof(T));
                return null;
            }
            ui.Open(data);
            if (ui.NaviData._Type == EUIType.FullScreen)
            {
                _OpenedFullScreenUI.Add(ui);
            }
            else if (ui.NaviData._Type == EUIType.Coexisting)
            {
                if (_CoexistingUI.ContainsKey(CurFullScreenUI))
                {

                }
                else
                {
                    _CoexistingUI[CurFullScreenUI] = new List<BaseUI>();
                }
                _CoexistingUI[CurFullScreenUI].Add(ui);
            }
            return ui;
        }

        public void Close<T>(T ui)
            where T : BaseUI
        {
            Debug.Log("Close t=" + ui.GetType());
            ui.CloseInternal();
            Push(ui);
        }

        // 关闭最后一个该类型的UI
        public void Close<T>()
            where T : BaseUI
        {
            var t = typeof(T);
            var ui = _OpenedFullScreenUI.FindLast((BaseUI tempUI) => tempUI.GetType() == t);
            if (ui == null)
            {
                Debug.LogErrorFormat("do not contains ui with type of {0}", t);
                return;
            }
            Debug.Log("Close t=" + ui.GetType());
            ui.CloseInternal();
            Push(ui as T);
        }
    }
}