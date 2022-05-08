using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.ProductAgg.Services;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;

namespace BookShop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        private Product()
        {

        }

        public Product(string title, string imageName, string description, long categoryId, long subCategoryId,
            long secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, description, slug, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
        }
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        public void Edit(string title, string description, long categoryId, long subCategoryId,
            long secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, description, slug, domainService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
        }

        public void SetProductImage(string image)
        {
            NullOrEmptyDomainDataException.CheckString(image, nameof(image));
            ImageName = image;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public string DeleteImage(long id)
        {
            var image = Images.SingleOrDefault(q => q.Id == id);
            if (image == null)
            {
                throw new NullOrEmptyDomainDataException("عکس یافت نشد");
            }
            Images.Remove(image);
            return image.ImageName;
        }

        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(q => q.ProductId = Id);
            Specifications = specifications;
        }

        public void Guard(string title, string description, string slug, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug != Slug)
            {
                if (domainService.IsSlugExist(slug.ToSlug()))
                {
                    throw new SlugIsDuplicateException();
                }
            }
        }
    }
}