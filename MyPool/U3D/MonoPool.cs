using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：MonoPool  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 20:03:22
// ================================
namespace Assets.JackCheng.MyPool
{
    public class MonoPool : MonoBehaviour
    {
        private AutoRestorePool<GameObject> pool ;
        [SerializeField]
        private MonoFactory factory;
        [SerializeField]
        private GameObject prefabe;
        [SerializeField]
        private Transform parent;
        void Awake() {
            factory = new MonoFactory(prefabe, parent);
            pool = new AutoRestorePool<GameObject>(factory, 20);
        }

        void Update() {
            pool.Check();
        }

        void OnGUI() {
            GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.TextField("激活数量:"+pool.GetActiveNum());
                GUILayout.TextField("未激活数量:" + pool.GetUnActiveNum());
                GUILayout.EndHorizontal();

                if (GUILayout.Button("生成")) {
                    IAutoRestoreObj<GameObject> reObj = pool.Pop();
                    reObj.Self().transform.position = new Vector3(UnityEngine.Random.Range(-4, 4), 0, UnityEngine.Random.Range(-4, 4));
                    TimeChecker checker = reObj.Self().GetComponent<TimeChecker>();
                    if(checker == null)
                        checker = reObj.Self().AddComponent<TimeChecker>();
                    checker.Init(10f);
                    factory.ShowObj(reObj.Self());
                    reObj.Checker = checker; 
                }

            GUILayout.EndVertical();
        }
    }
}
