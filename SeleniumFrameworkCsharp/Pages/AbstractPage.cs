using SeleniumFrameworkCsharp.Modules.Executors;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using System;

namespace SeleniumFrameworkCsharp.Pages
{
    public abstract class AbstractPage
    {
        public SeleniumExecutor executor;
        public PageHeader pageHeader;
        public NavigationBar navigationBar;

        public AbstractPage(SeleniumExecutor executor)
        {
            this.executor = executor;
            pageHeader = new PageHeader(executor);
            navigationBar = new NavigationBar(executor);
        }

    }
}
