using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：AutoRestorePool  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 20:13:30
// ================================
namespace Assets.JackCheng.MyPool
{
    public class AutoRestorePool<T> : IBasePool<IAutoRestoreObj<T>>
    {
        private readonly BasePool<T> pool;
        private readonly List<AutoRestoreObj<T>> listCheckObjs = new List<AutoRestoreObj<T>>();

        private IBaseFactory<T> factory;

        public AutoRestorePool(IBaseFactory<T> _factory, int _capacity)
        {
            this.pool = new BasePool<T>(_factory, _capacity);
            this.factory = _factory;
        }

        public void Check() {
            
            for (int i = 0; i < listCheckObjs.Count; i++) {
                IAutoRestoreObj<T> reObj = listCheckObjs[i];
                IAutoRestoreChecker checker = reObj.Checker;
                if (checker != null &&checker.IsRestore) {
                    
                    pool.Restore(listCheckObjs[i].Self());

                    listCheckObjs.RemoveAt(i);
                    i--;
                }
            }
        }

        //-------------------------------

        public IAutoRestoreObj<T> Pop() {
            T t = pool.Pop();

            AutoRestoreObj<T> at = new AutoRestoreObj<T>(t);

            listCheckObjs.Add(at);

            return at;
        }

        public void Add() {
            pool.Add();
        }

        public void Clear() {
            pool.Clear();
            for (int i = 0; i < listCheckObjs.Count; i++)
            {
                AutoRestoreObj<T> t = listCheckObjs[i];
                this.factory.DestroyObj(t.Self());
            }
            listCheckObjs.Clear();
        }

        public int GetActiveNum() {
            return pool.GetActiveNum();
        }

        public int GetUnActiveNum() {
            return pool.GetUnActiveNum();
        }
    }
}
