using System;
using System.Collections.Generic;

namespace Pawns
{
    public class StateMovimentGenerator
    {
        private BoardMovimentEnumeration _boardMovimentEnumeration;
        private StateConfigurationEnumeration _stateConfigurationEnumeration;


        public StateMovimentGenerator(StateConfigurationEnumeration stateConfigurationEnumeration, BoardMovimentEnumeration boardMovimentEnumeration)
        {
            this._stateConfigurationEnumeration = stateConfigurationEnumeration;
            this._boardMovimentEnumeration = boardMovimentEnumeration;
        }

        public StateMovimentEnumeration Enumerate()
        {
            var validMovimentsPlayers = new Dictionary<State, IEnumerable<State>>();
            var states = _stateConfigurationEnumeration.StateConfigurations;

            foreach (var state in states)
            {
                var validStates = new List<State>();

                foreach (var validMoviment in _boardMovimentEnumeration.GetValidMoviments(state.Player, state.Configuration))
                    validStates.Add(new State(1 - state.Player, validMoviment));

                validMovimentsPlayers.Add(state, validStates);
            }

            return new StateMovimentEnumeration()
            {
                StateMoviments = validMovimentsPlayers
            };
        }
    }
}