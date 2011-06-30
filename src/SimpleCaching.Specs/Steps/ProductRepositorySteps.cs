using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using TechTalk.SpecFlow;

namespace SimpleCaching.Specs.Steps
{
    [Binding]
    public class ProductRepositorySteps
    {
        private Mock<IProductRepository> fakeProductRepository;
        private CachedProductRepository cachedProductRepository;

        [Given(@"I have an instance of the product repository class")]
        public void x()
        {
            fakeProductRepository = new Mock<IProductRepository>();
        }

        [Given(@"I have a cached product repository class")]
        public void GivenIHaveACachedProductRepositoryClass()
        {
            cachedProductRepository = new CachedProductRepository(() => fakeProductRepository.Object);
        }

        [When(@"I call the GetAll method on the product repository class")]
        public void WhenICallTheGetAllMethodOnTheProductRepositoryClass()
        {
            cachedProductRepository.GetAll();
        }

        [Then(@"the base product repository class should be called (.*) time")]
        [Then(@"the base product repository class should be called (.*) times")]
        public void ThenTheBaseProductRepositoryClassShouldBeCalledOnce(int count)
        {
            fakeProductRepository.Verify(x => x.GetAll(), Times.Exactly(count));
        }
    }

    public class CachedProductRepository : Cache, IProductRepository
    {
        private readonly Func<IProductRepository> productRepository;
        private IList<string> products;

        public CachedProductRepository(Func<IProductRepository> productRepository)
        {
            this.productRepository = productRepository;
        }

        public override void SetupTheCache()
        {
            products = productRepository().GetAll().ToList();
        }

        public IEnumerable<string> GetAll()
        {
            CheckTheCache();
            return products;
        }
    }

    public interface IProductRepository
    {
        IEnumerable<string> GetAll();
    }
}