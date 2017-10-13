namespace Well.Interpretation.Configuration._Implementations
{
    public abstract class BaseResolverDecorator : IResolver
    {
        private readonly IResolver _resolver;

        protected BaseResolverDecorator(IResolver resolver)
        {
            _resolver = resolver;
        }

        public void Register<TInterface>(TInterface instance) where TInterface : class
        {
            _resolver.Register(instance);
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            return _resolver.Resolve<TInterface>();
        }
    }
}