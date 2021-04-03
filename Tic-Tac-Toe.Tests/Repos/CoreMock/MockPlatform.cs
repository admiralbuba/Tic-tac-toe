using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Tests.Repos.CoreMock
{
    public class MockPlatform : ITicTacToe
    {
        public object GetEndGameMessage(MapValues winner)
        {
            object a = null;
            return a;
        }

        public void ReleaseButtons()
        {
        }

        public void ShowDrow()
        {
        }

        public void UpdateTurnLabel()
        {
        }

        public void UpdateWinnerLabel()
        {
        }
    }
}
