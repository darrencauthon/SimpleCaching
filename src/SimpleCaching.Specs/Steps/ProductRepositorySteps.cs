using Moq;
using TechTalk.SpecFlow;

namespace SimpleCaching.Specs.Steps
{
    [Binding]
    public class ProductRepositorySteps
    {
        private Mock<IProductRepository> fakeProductRepository;

        [Given(@"I have an instance of the product repository class")]
        public void x()
        {
            fakeProductRepository = new Mock<IProductRepository>();
        }
    }

    public interface IProductRepository
    {
    }
}