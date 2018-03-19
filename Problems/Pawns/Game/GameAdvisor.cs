using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pawns
{
    public class GameAdvisor
    {
        private readonly StateMovimentEnumeration _states;
        private readonly Dictionary<State, int> vencedor;

        public GameAdvisor(StateMovimentEnumeration states, BoardConfigurationEnumeration board)
        {
            var terminais = states.StateMoviments.Keys.Where(s => s.IsTerminal());


            vencedor = new Dictionary<State, int>();
            this._states = Search(states, board);


            var state = GameFactory.GetInitialState(1);
            var vence = vencedor[state];

            if (vence == 2)
                throw new NotImplementedException("busca não funcionou");
        }

        public State GetNextMoviment(State currentOutsideState)
        {
            var currentState = _states.StateMoviments.Keys.First(s => s.Equals(currentOutsideState));
            var possibleStates = this._states.StateMoviments[currentState];

            if (possibleStates.Count() == 0 && !currentState.IsGameOver())
                return currentState;

            if (vencedor[currentState] == 3)
            {
                foreach (var item in possibleStates)
                {
                    var cod = vencedor[item];
                    if (cod == 2)
                        return item;
                }
            }

            return possibleStates.ElementAt(new Random().Next(0, possibleStates.Count() - 1));
        }

        private StateMovimentEnumeration Search(StateMovimentEnumeration states, BoardConfigurationEnumeration board)
        {
            foreach (var state in states.StateMoviments)
                if(!vencedor.ContainsKey(state.Key))
                    RecursiveDepthSearch(state.Key, states);

            return states;
        }

        private void RecursiveDepthSearch(State currentState, StateMovimentEnumeration statesEnumeration)
        {
            // mark as visited
            vencedor.Add(currentState, 1);

            // no terminal node has a winning strategy
            if (currentState.IsGameOver())
            {
                vencedor[currentState] = 2;
                return;
            }

            var adjacentStates = statesEnumeration.StateMoviments[currentState];
            foreach (var adjacentState in adjacentStates)
            {
                if (!vencedor.ContainsKey(adjacentState))
                    RecursiveDepthSearch(adjacentState, statesEnumeration);
                if (vencedor[adjacentState] == 2)
                    vencedor[currentState] = 3;
            }

            if (vencedor[currentState] == 1)
                vencedor[currentState] = 2;
        }
    }
}
