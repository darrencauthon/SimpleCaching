// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.6.1.0
//      SpecFlow Generator Version:1.6.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace SimpleCaching.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.6.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Provide caching")]
    public partial class ProvideCachingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ProvideCaching.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Provide caching", "In order to make caching easy\r\nAs a programmer\r\nI want to inherit from a cache ob" +
                    "ject that handles caching in memory", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            this.FeatureBackground();
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calling a method on a cached repository only once")]
        public virtual void CallingAMethodOnACachedRepositoryOnlyOnce()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calling a method on a cached repository only once", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I have an instance of the product repository class");
#line 10
 testRunner.And("I have a cached product repository class");
#line 11
 testRunner.When("I call the GetAll method on the product repository class");
#line 12
 testRunner.Then("the base product repository class should be called 1 time");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calling a method on a cached repository twice")]
        public virtual void CallingAMethodOnACachedRepositoryTwice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calling a method on a cached repository twice", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I have an instance of the product repository class");
#line 16
 testRunner.And("I have a cached product repository class");
#line 17
 testRunner.When("I call the GetAll method on the product repository class");
#line 18
 testRunner.And("I call the GetAll method on the product repository class");
#line 19
 testRunner.Then("the base product repository class should be called 1 time");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calling a cached method, the cache is invalidated, and then the cached repository" +
            " is called again")]
        public virtual void CallingACachedMethodTheCacheIsInvalidatedAndThenTheCachedRepositoryIsCalledAgain()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calling a cached method, the cache is invalidated, and then the cached repository" +
                    " is called again", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have an instance of the product repository class");
#line 23
 testRunner.And("I have a cached product repository class");
#line 24
 testRunner.When("I call the GetAll method on the product repository class");
#line 25
 testRunner.And("the cache for IProductRepository is marked as invalid");
#line 26
 testRunner.And("I call the GetAll method on the product repository class");
#line 27
 testRunner.Then("the base product repository class should be called 2 times");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
