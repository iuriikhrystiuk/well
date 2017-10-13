using System.IO;
using Well.Interpretation.Reader;
using Well.Interpretation.Reader._Implementations;

namespace Well.Interpretation.Input._Implementations
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