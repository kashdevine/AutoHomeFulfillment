using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Models
{
    public class WPSearchAndReplace
    {
        private IWebDriver _driver;
        public string url => ".idxbrokerhome.com/wp-admin/tools.php?page=better-search-replace";
        public IWebElement searchField => _driver.FindElement(By.Id("search_for"));
        public IWebElement replaceField => _driver.FindElement(By.Id("replace_with"));
        public IWebElement caseInsensitiveCheckBox => _driver.FindElement(By.Id("case_insensitive"));
        public IWebElement dryRunCheckBox => _driver.FindElement(By.Id("dry_run"));
        public IWebElement runButton => _driver.FindElement(By.Id("bsr-submit"));
        public IWebElement tablesSelection => _driver.FindElement(By.Id("bsr-table-select"));

        public readonly string firstImpressionDomain = "idx-firstimpression.homewithidxbroker.com";
        public readonly string firstImpressionIDXDomain = "idx-firstimpression.idxbroker.com";

        public WPSearchAndReplace(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
