﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using YoutubeSignInAndVideoPlayback.WebDriver;

namespace YoutubeSignInAndVideoPlayback.tests
{
    public abstract class BaseTest
    {
        private const int TimeoutSec = 5;       

        [SetUp]
        public void Initialize()
        {
            Driver.GetDriver();
            Driver.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeoutSec);
        }

        [TearDown]
        public void EndTest()
        {
            Driver.Quit();
        }
    }
}