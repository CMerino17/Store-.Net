namespace bootcamp_store_backend.Infrastructure.Specs
{
    public interface ISpecificationParser<T>
    {
        Specification<T> ParseSpecification(string filter);
    }
}
