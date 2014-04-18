namespace Swashbuckle.Core.Swagger
{
    public interface IResourceListingFilter
    {
        void Apply(ResourceListing resourceListing);
    }
}