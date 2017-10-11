using SimpleInjector;
using Well.Calculator.LexicalAnalysis;
using Well.Calculator.Tokens;
using Well.Calculator.Tokens.Base;

namespace Well.Calculator.Configuration
{
    public class Configurator : IResolver
    {
        private readonly Container _container;

        public Configurator()
        {
            _container = new Container();
            _container.Register<IProcessor, Processor>();
            _container.Register<ILexer, Lexer>();
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            _container.Verify();
            return _container.GetInstance<TInterface>();
        }

        public void Register<TInterface>(TInterface instance) where TInterface : class
        {
            _container.Register(() => instance);
        }
    }
}