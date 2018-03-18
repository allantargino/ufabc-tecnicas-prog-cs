using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pawns
{
    public class GameAdvisor
    {
        private readonly StateMovimentEnumeration _states;

        public GameAdvisor(StateMovimentEnumeration states, BoardConfigurationEnumeration board)
        {
            this._states = Search(states, board);
        }

        public State GetNextMoviment(State currentState)
        {
            var possibleStates = this._states.StateMoviments[currentState];

            if (currentState.NodeProperties.HasWinningStrategy)
                possibleStates.First(s => !s.NodeProperties.HasWinningStrategy);

            return possibleStates.ElementAt(new Random().Next(0, possibleStates.Count() - 1));
        }

        private StateMovimentEnumeration Search(StateMovimentEnumeration states, BoardConfigurationEnumeration board)
        {
            foreach (var state in states.StateMoviments)
                RecursiveDepthSearch(state.Key, states);

            return states;
        }

        private bool RecursiveDepthSearch(State currentState, StateMovimentEnumeration statesEnumeration)
        {
            if (currentState.NodeProperties.WasVisited)
                return currentState.NodeProperties.HasWinningStrategy;

            if (currentState.IsTerminal())
                return false;

            bool enemyWinningStrategy = false;
            var adjacentStates = statesEnumeration.StateMoviments[currentState];
            foreach (var adjacentState in adjacentStates)
            {
                enemyWinningStrategy = enemyWinningStrategy || RecursiveDepthSearch(adjacentState, statesEnumeration);
            }

            currentState.NodeProperties.WasVisited = true;
            currentState.NodeProperties.HasWinningStrategy = !enemyWinningStrategy;

            return currentState.NodeProperties.HasWinningStrategy;
        }
    }
}
