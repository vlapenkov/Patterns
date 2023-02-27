namespace Interpreter
{
    class Context

    {
        Dictionary<string, long> _longVariables;
        Dictionary<string, string> _stringVariables;
        Dictionary<string, bool> _boolVariables;
        public Context()
        {
            _longVariables = new Dictionary<string, long>();
            _stringVariables = new Dictionary<string, string>();
            _boolVariables = new Dictionary<string, bool>();
        }
        // получаем значение переменной по ее имени
        public long GetLongVariable(string name)
        {
            return _longVariables[name];
        }

        public string GetStringVariable(string name)
        {
            if (!_stringVariables.ContainsKey(name)) throw new Exception($"Переменная с именем {name} отсутствует.");
            return _stringVariables[name];
        }

        public bool GetBoolVariable(string name)
        {
            return _boolVariables[name];
        }

        public void SetVariable(string name, long value)
        {
            if (_longVariables.ContainsKey(name))
                _longVariables[name] = value;
            else
                _longVariables.Add(name, value);
        }

        public void SetVariable(string name, bool value)
        {
            if (_boolVariables.ContainsKey(name))
                _boolVariables[name] = value;
            else
                _boolVariables.Add(name, value);
        }

        public void SetVariable(string name, string value)
        {
            if (_stringVariables.ContainsKey(name))
                _stringVariables[name] = value;
            else
                _stringVariables.Add(name, value);
        }
    }
}
