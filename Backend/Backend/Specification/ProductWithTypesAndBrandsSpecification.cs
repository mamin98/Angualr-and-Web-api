using Backend.Entities;

namespace Backend.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(string sort)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);

            AddOrderBy(o => o.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(o => o.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(o => o.Price);
                        break;

                    default:
                        AddOrderBy(o => o.Name);
                        break;
                }
            }

        }
        public ProductWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }

    }
}
