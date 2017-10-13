using Well.Interpretation.Input;

namespace Well.Interpretation.Configuration._Implementations
{
    internal class InputConfigured : BaseResolverDecorator, IInputConfigured
    {
        public InputConfigured(IResolver resolver, IInput input)
            : base(resolver)
        {
            Input = input;
            Register(input);
        }

        public IInput Input { get; }
    }
}