using Backend.Entities;

namespace Backend.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification() 
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);

        }
        public ProductWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id) 
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }

    }
}
