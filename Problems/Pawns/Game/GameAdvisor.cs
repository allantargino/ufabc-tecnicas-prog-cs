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


            var state = GameFactory.GetInitialState(0);
            var currentState = _states.StateMoviments.Keys.First(s => s.Equals(state));

        }

        public State GetNextMoviment(State currentOutsideState)
        {
            var currentState = _states.StateMoviments.Keys.First(s => s.Equals(currentOutsideState));
            var possibleStates = this._states.StateMoviments[currentState];

            if (possibleStates.Count() == 0 && !currentState.IsTerminal())
                return currentState;

            if (currentState.NodeProperties.HasWinningStrategy)
                return possibleStates.First(s => !s.NodeProperties.HasWinningStrategy);

            return possibleStates.ElementAt(new Random().Next(0, possibleStates.Count() - 1));
        }

        private StateMovimentEnumeration Search(StateMovimentEnumeration states, BoardConfigurationEnumeration board)
        {
            foreach (var state in states.StateMoviments)
                if(!state.Key.NodeProperties.WasVisited)
                    RecursiveDepthSearch(state.Key, states);

            return states;
        }

        private bool RecursiveDepthSearch(State currentState, StateMovimentEnumeration statesEnumeration)
        {
            if (currentState.NodeProperties.WasVisited)
                return currentState.NodeProperties.HasWinningStrategy;

            if (currentState.IsTerminal())
            {
                currentState.NodeProperties.WasVisited = true;
                currentState.NodeProperties.HasWinningStrategy = false;
                return currentState.NodeProperties.HasWinningStrategy;
            }

            bool winningStrategy = false;
            var adjacentStates = statesEnumeration.StateMoviments[currentState];
            foreach (var adjacentState in adjacentStates)
            {
                var strategy = RecursiveDepthSearch(adjacentState, statesEnumeration);
                if (strategy == false)
                {
                    winningStrategy = true;
                }
            }

            currentState.NodeProperties.WasVisited = true;
            currentState.NodeProperties.HasWinningStrategy = winningStrategy;

            return currentState.NodeProperties.HasWinningStrategy;
        }
    }
}
