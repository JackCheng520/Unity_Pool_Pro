using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：BasePool  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 19:12:05
// ================================
namespace Assets.JackCheng.MyPool
{
    public class BasePool<T> : IBasePool<T>
    {
        private readonly List<T> listActiveObjs = new List<T>();
        private readonly List<T> listUnactiveObjs = new List<T>();
        private readonly IBaseFactory<T> factory;

        private readonly int capacity;

        public BasePool(IBaseFactory<T> _factory, int _capacity)
        {
            factory = _factory;
            capacity = _capacity;
        }

        public void Check() { 
            
        }

        public T Pop()
        {
            T t ;
            if (listUnactiveObjs.Count > 0)
            {
                t = listUnactiveObjs[0];

                listUnactiveObjs.RemoveAt(0);
            }
            else {
                t = factory.CreateObj();
            }

            listActiveObjs.Add(t);
            
            return t;
        }

        public void Add()
        {
            if (listActiveObjs.Count + listUnactiveObjs.Count < capacity)
            {
                T t = factory.CreateObj();
                listUnactiveObjs.Add(t);
            }
            else {
                throw new System.Exception("pool num max");
            }
        }

        public void Restore(T t) {

            factory.HideObj(t);

            if (listUnactiveObjs.Count + listActiveObjs.Count <= capacity)
            {
                listUnactiveObjs.Add(t);

                listActiveObjs.Remove(t);
            }
            else 
            {
                listActiveObjs.Remove(t);

                factory.DestroyObj(t);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < listActiveObjs.Count; i++)
            {
                factory.DestroyObj(listActiveObjs[i]);
            }
            listActiveObjs.Clear();

            for (int i = 0; i < listUnactiveObjs.Count; i++) {
                factory.DestroyObj(listUnactiveObjs[i]);
            }
            listUnactiveObjs.Clear();
        }

        public int GetActiveNum() {
            return listActiveObjs.Count;
        }

        public int GetUnActiveNum() {
            return listUnactiveObjs.Count;
        }
    }
}
