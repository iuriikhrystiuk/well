using System.IO;
using Well.Calculator.Reader;

namespace Well.Calculator.Input
{
    public class FileInput : IInput
    {
        private readonly string _fileLocation;

        public FileInput(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public IReader Read()
        {
            return new StringSequenceReader(File.ReadAllText(_fileLocation));
        }
    }
}