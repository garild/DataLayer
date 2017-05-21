using DataLayer.ResultType.Interface;
using System;
using System.Collections.Generic;

namespace DataLayer.ResultType.Repository
{
    public sealed class QueryResult<T> : IDataResult<T>
    {
        public QueryResult()
        {
            _success = false;
        }
        private bool _success;

        private List<T> _valueList;

        private T _value;
        public bool success
        {
            get
            {
                return _success;
            }
        }
        public List<T> valueList
        {
            get
            {
                return _valueList;
            }

            set
            {
                if (value == null || value.Count == 0)
                {
                    _success = false;
                    _valueList = new List<T>();
                    return;
                }
                _success = true;
                _valueList = value;
            }
        }
        public T value
        {
            get
            {
                return _value;
            }
            set
            {
               
                if (value == null ||  value.Equals(Activator.CreateInstance<T>()))
                {
                    _success = false;
                    _value = default(T);
                    return;
                }
                _success = true;
                _value = value;
            }
        }

    }

}

