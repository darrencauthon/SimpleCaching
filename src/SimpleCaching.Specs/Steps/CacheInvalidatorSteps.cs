using TechTalk.SpecFlow;

namespace SimpleCaching.Specs.Steps
{
    [Binding]
    public class CacheInvalidatorSteps
    {
        [When(@"the cache for IProductRepository is marked as invalid")]
        public void WhenTheCacheForIProductRepositoryIsMarkedAsInvalid()
        {
            CacheInvalidator.MarkAsInvalid(typeof (IProductRepository));
        }
    }
}