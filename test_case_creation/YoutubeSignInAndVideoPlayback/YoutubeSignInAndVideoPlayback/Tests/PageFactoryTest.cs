﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using YoutubeSignInAndVideoPlayback.pages.PageFactoryPattern;

namespace YoutubeSignInAndVideoPlayback.tests
{
    class PageFactoryTest
    {
        private const string USERNAME = "mattaku.ad@gmail.com";
        private const string PASSWORD = "Q!w2e3r4";
        private const string SEARCH_STRING = "gnossienne 1 piano";
        private const string EXPECTED_PAGE_TITLE = "ERIK SATIE Gnossienne 1 - Alessio Nanni, piano - YouTube";
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }

        [Test]
        public void YoutubeSignInAndVideoPlaybackTest_PageFactory()
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenUrl();
            SignInPage signInPage = startPage.OpenSignInPage();
            HomePage homePage = signInPage.SignIn(USERNAME, PASSWORD);
            FirstVideoPage firstVideoPage = homePage.SelectVideo(SEARCH_STRING);
            Thread.Sleep(5000);
            string actualPageTitle = firstVideoPage.GetPageTitle();

            Assert.AreEqual(EXPECTED_PAGE_TITLE, actualPageTitle);
            firstVideoPage.SignOut();
            driver.Quit();

        }

    }
}
