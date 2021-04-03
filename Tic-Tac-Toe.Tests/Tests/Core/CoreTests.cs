using System;
using System.Collections.Generic;
using System.Text;
using Core;
using NUnit.Framework;
using Tic_Tac_Toe.Tests.Repos.Core;
using Tic_Tac_Toe.Tests.Repos.CoreMock;

namespace Tic_Tac_Toe.Tests.Tests.Core
{
    [TestFixture]
    public class CoreTests : BaseCoreTest
    {
        [Test]
        public void CheckForWinner()
        {
            TicTacToe.Instance.MakeTurn("A00", "X");
            TicTacToe.Instance.MakeTurn("B10", "O");
            TicTacToe.Instance.MakeTurn("A01", "X");
            TicTacToe.Instance.MakeTurn("B11", "O");
            Assert.IsTrue(TicTacToe.Instance.MakeTurn("A02", "X", new MockPlatform()));
        }
    }
}
