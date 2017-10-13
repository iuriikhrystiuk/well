namespace Well.Interpretation.Reader
{
    public interface IReader
    {
        bool Next();

        char Peek();
    }
}