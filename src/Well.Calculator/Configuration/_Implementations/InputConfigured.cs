using Well.Calculator.Input;

namespace Well.Calculator.Configuration
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