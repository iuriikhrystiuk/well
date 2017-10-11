using System.IO;

namespace Well.Calculator.Input
{
    public class FileInput : IInput
    {
        private readonly string _fileLocation;

        public FileInput(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public string Read()
        {
            return File.ReadAllText(_fileLocation);
        }
    }
}