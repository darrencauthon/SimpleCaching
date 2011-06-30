using System;
using System.Collections.Generic;
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

        public CachedProductRepository(Func<IProductRepository> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<string> GetAll()
        {
            return productRepository().GetAll();
        }
    }

    public interface IProductRepository
    {
        IEnumerable<string> GetAll();
    }
}