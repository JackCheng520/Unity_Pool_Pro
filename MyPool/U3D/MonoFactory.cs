using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：MonoFactory  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 19:45:08
// ================================
namespace Assets.JackCheng.MyPool
{
    public class MonoFactory : IBaseFactory<GameObject>
    {

        private GameObject prefab;

        private Transform parent;
        public MonoFactory(GameObject _prefab, Transform _parent)
        {
            this.prefab = _prefab;
            this.parent = _parent;
        }

        public GameObject CreateObj()
        {
            GameObject obj = null;
            if (this.prefab != null)
            {
                obj = UnityEngine.Object.Instantiate(this.prefab) as GameObject;
                obj.transform.SetParent(this.parent, false);

                HideObj(obj);
            }
            return obj;
        }

        public void DestroyObj(GameObject t) {
            GameObject.Destroy(t);
        }

        public bool ShowObj(GameObject t)
        {
            t.SetActive(true);
            return true;
        }

        public bool HideObj(GameObject t)
        {
            t.SetActive(false);
            return true;
        }
    }
}
