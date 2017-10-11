namespace Well.Calculator.Reader
{
    public class StringReader : IReader
    {
        private readonly string _input;
        private int _currentPosition;
        
        public StringReader(string input)
        {
            _input = input;
            _currentPosition = 0;
        }
        
        public bool Next()
        {
            _currentPosition++;
            return _currentPosition < _input.Length;
        }

        public char Peek() => _input[_currentPosition];
    }
}