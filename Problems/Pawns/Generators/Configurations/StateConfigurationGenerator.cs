using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class StateConfigurationGenerator
    {
        private BoardConfigurationEnumeration boardConfigurationEnumeration;

        public StateConfigurationGenerator(BoardConfigurationEnumeration boardConfigurationEnumeration)
        {
            this.boardConfigurationEnumeration = boardConfigurationEnumeration;
        }

        public StateConfigurationEnumeration Enumerate()
        {
            var stateConfigurations = new List<State>();
            for (int player= 1; player <=2; player++)
            {
                foreach (var item in boardConfigurationEnumeration.BoardConfigurations)
                {
                    var configuration = item.Value;
                    stateConfigurations.Add(new State(player, configuration));
                }
            }
            return new StateConfigurationEnumeration()
            {
                StateConfigurations = stateConfigurations
            };
        }
    }
}
