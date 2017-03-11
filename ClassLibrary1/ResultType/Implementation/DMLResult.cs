using DataLayer.ResultType.Interface;

namespace DataLayer.ResultType.Implementation
{
    public sealed class DMLResult<T> : IDmlResult<T>
    {
        public DMLResult()
        {
            _success = false;
        }
        private bool _success;
        private bool _error;
        private T _value;
        public bool Error
        {
            get
            {
                return _error;
            }
        }

        public bool Succeed
        {
            get
            {
                return _success;
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value == null)
                {
                    _error = true;
                    _value = default(T);
                }
                _success = true;
                _value = value;
            }
        }
    }
}
