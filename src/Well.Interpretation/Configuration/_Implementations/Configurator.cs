using SimpleInjector;
using Well.Interpretation.Interpreter;
using Well.Interpretation.LexicalAnalysis;
using Well.Interpretation.LexicalAnalysis._Implementations;
using Well.Interpretation.Statements;
using Well.Interpretation.Statements.Base;

namespace Well.Interpretation.Configuration._Implementations
{
    public class Configurator : IResolver
    {
        private readonly Container _container;

        public Configurator()
        {
            _container = new Container();
            _container.Register<IProcessor, Processor>();
            _container.Register<ILexer, Lexer>();
            _container.Register<IStatementBuilder, DefaultStatementBuilder>();
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