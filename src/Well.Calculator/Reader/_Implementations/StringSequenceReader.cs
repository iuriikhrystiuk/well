namespace Well.Calculator.Reader
{
    internal class StringSequenceReader : IReader
    {
        private readonly string _input;
        private int _currentPosition;
        
        public StringSequenceReader(string input)
        {
            _input = input;
            _currentPosition = -1;
        }
        
        public bool Next()
        {
            _currentPosition++;
            return _currentPosition < _input.Length;
        }

        public char Peek() => _input[_currentPosition];
    }
}