#SimpleCaching

A simple way to implement caching in your C# projects.  It was intended to be used as a "wrapper" around your actual classes (like repositories), which are then injected as singletons into your IoC container. 

*So for example, instead of registering IAccountRepository => AccountRepository, you'd register a Cache implementation of IAccountRepository that depends on AccountRepository.

##Just Two Classes

###Cache

```c#

    public interface IProductRepository
    {
        IEnumerable<Product> All();
        Product FindById(string id);
    }

    public class CachedProductRepository : Cache, IProductRepository 
    {
        private Func<IAccountRepository> accountRepository;
        private IEnumerable<Product> products;
        
        public CachedProductRepository(Func<IAccountRepository> accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        
        public void SetupTheCache(){
            // don't worry, the Cache base class locks around this
            products = accountRepository().All();
        }
        
        public IEnumerable<Product>All(){
            // this method on Cache will check the cache and run SetupTheCache if necessary
            CheckTheCache();
            return products;
        }
        
        public Product FindById(string id){
            CheckTheCache();
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
```

###CacheInvalidator
```c#
    // this will cause the cache to be marked as invalid, causing SetupTheCache to be called again 
    CacheInvalidator.MarkAsInvalid(typeof(CachedProductRepository));
```