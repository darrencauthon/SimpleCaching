using TechTalk.SpecFlow;

namespace SimpleCaching.Specs.Steps
{
    [Binding]
    public class CacheInvalidatorSteps
    {
        [When(@"the cache for the product repository is marked as invalid")]
        public void WhenTheCacheForIProductRepositoryIsMarkedAsInvalid()
        {
            CacheInvalidator.MarkAsInvalid(typeof (CachedProductRepository));
        }
    }
}