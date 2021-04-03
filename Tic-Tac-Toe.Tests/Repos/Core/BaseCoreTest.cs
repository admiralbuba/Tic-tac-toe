using System;
using System.Collections.Generic;
using System.Text;
using Core;
using NUnit.Framework;

namespace Tic_Tac_Toe.Tests.Repos.Core
{
    public class BaseCoreTest
    {
        [TearDown]
        [SetUp]
        public void Setup()
        {
            TicTacToe.Instance.ResetGame();
        }
    }
}
