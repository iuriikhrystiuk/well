namespace Well.Calculator.Reader
{
    public interface IReader
    {
        bool Next();

        char Peek();
    }
}