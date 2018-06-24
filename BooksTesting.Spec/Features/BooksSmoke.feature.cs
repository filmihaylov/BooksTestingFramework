﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BooksTesting.Spec.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class BooksSmokeFeature : Xunit.IClassFixture<BooksSmokeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "BooksSmoke.feature"
#line hidden
        
        public BooksSmokeFeature(BooksSmokeFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BooksSmoke", "\tSmoke suite lives here\r\n\tto test the basic functionality of product", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Add a Book")]
        [Xunit.TraitAttribute("FeatureTitle", "BooksSmoke")]
        [Xunit.TraitAttribute("Description", "Add a Book")]
        [Xunit.TraitAttribute("Category", "smoke")]
        public virtual void AddABook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a Book", new string[] {
                        "smoke"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table1.AddRow(new string[] {
                        "OscardWild",
                        "Dorian gray",
                        "11",
                        "book about something"});
#line 8
 testRunner.Given("I have books", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table2.AddRow(new string[] {
                        "OscardWild",
                        "Dorian gray",
                        "11",
                        "book about something"});
#line 11
 testRunner.Then("The book should be added with", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Update a Book")]
        [Xunit.TraitAttribute("FeatureTitle", "BooksSmoke")]
        [Xunit.TraitAttribute("Description", "Update a Book")]
        [Xunit.TraitAttribute("Category", "smoke")]
        public virtual void UpdateABook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a Book", new string[] {
                        "smoke"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table3.AddRow(new string[] {
                        "UpdateBook",
                        "TitleUpdateBook",
                        "12",
                        "book about something"});
#line 18
 testRunner.Given("I have books", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table4.AddRow(new string[] {
                        "UpdateBookUpdated",
                        "TitleUpdateBookUpdated",
                        "12",
                        "book about something Updated"});
#line 21
 testRunner.And("I update a book with values", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table5.AddRow(new string[] {
                        "UpdateBookUpdated",
                        "TitleUpdateBookUpdated",
                        "12",
                        "book about something Updated"});
#line 24
 testRunner.Then("The book should be Updated with values", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Delete a Book")]
        [Xunit.TraitAttribute("FeatureTitle", "BooksSmoke")]
        [Xunit.TraitAttribute("Description", "Delete a Book")]
        [Xunit.TraitAttribute("Category", "smoke")]
        public virtual void DeleteABook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a Book", new string[] {
                        "smoke"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table6.AddRow(new string[] {
                        "OscardWild",
                        "Dorian gray",
                        "13",
                        "book about something"});
#line 30
 testRunner.Given("I have books", ((string)(null)), table6, "Given ");
#line 33
 testRunner.And("I delete a book with id \'13\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("The book should be Deleted with id \'13\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get All Books")]
        [Xunit.TraitAttribute("FeatureTitle", "BooksSmoke")]
        [Xunit.TraitAttribute("Description", "Get All Books")]
        [Xunit.TraitAttribute("Category", "smoke")]
        public virtual void GetAllBooks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get All Books", new string[] {
                        "smoke"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I Get All Books", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.Then("All Books should be received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Search a Book by name")]
        [Xunit.TraitAttribute("FeatureTitle", "BooksSmoke")]
        [Xunit.TraitAttribute("Description", "Search a Book by name")]
        [Xunit.TraitAttribute("Category", "smoke")]
        public virtual void SearchABookByName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a Book by name", new string[] {
                        "smoke"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table7.AddRow(new string[] {
                        "OscardWild",
                        "Title test",
                        "14",
                        "book about something"});
#line 44
 testRunner.Given("I have books", ((string)(null)), table7, "Given ");
#line 47
 testRunner.And("I search for the books title \'Title test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Id",
                        "Description"});
            table8.AddRow(new string[] {
                        "OscardWild",
                        "Title test",
                        "14",
                        "book about something"});
#line 48
 testRunner.Then("the book should be found", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                BooksSmokeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                BooksSmokeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
