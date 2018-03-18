using System;
using System.Collections.Generic;

namespace Pawns
{
    public class PlayerMovimentGenerator
    {
        private PlayerConfigurationEnumeration _playerConfigurationEnumeration { get; }

        public PlayerMovimentGenerator(PlayerConfigurationEnumeration playerConfigurationEnumeration)
        {
            _playerConfigurationEnumeration = playerConfigurationEnumeration;
        }

        public PlayerMovimentEnumeration Enumerate()
        {
            var validMovimentsPlayer1 = new Dictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>>();
            var validMovimentsPlayer2 = new Dictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>>();

            foreach (var playerConfiguration in _playerConfigurationEnumeration.PlayerConfigurations)
            {
                var moviment = playerConfiguration.Value;

                var validMoviments1 = GenerateValidMovimentsForPlayer1(moviment);
                validMovimentsPlayer1.Add(moviment, validMoviments1);

                var validMoviments2 = GenerateValidMovimentsForPlayer2(moviment);
                validMovimentsPlayer2.Add(moviment, validMoviments2);
            }

            return new PlayerMovimentEnumeration()
            {
                ValidMovimentsPlayer1 = validMovimentsPlayer1,
                ValidMovimentsPlayer2 = validMovimentsPlayer2
            };
        }

        private IEnumerable<PlayerConfiguration> GenerateValidMovimentsForPlayer1(PlayerConfiguration playerConfiguration)
        {
            List<PlayerConfiguration> validMoviments = new List<PlayerConfiguration>();

            int pos1 = playerConfiguration.PositionPlayer1;
            int pos2 = playerConfiguration.PositionPlayer2;

            if (pos1 == 4) return validMoviments;
            if (pos1 == 3 && pos2 == 4) return validMoviments;

            if (pos1 == pos2 - 1)
            {
                validMoviments.Add(_playerConfigurationEnumeration.GetPlayerConfiguration(pos1 + 2, pos2));
                return validMoviments;
            }

            int limite;
            if (pos1 < pos2) limite = pos2;
            else limite = 5;

            for (int i = pos1 + 1; i <= limite - 1; i++)
            {
                validMoviments.Add(_playerConfigurationEnumeration.GetPlayerConfiguration(i, pos2));
            }
            return validMoviments;
        }

        private IEnumerable<PlayerConfiguration> GenerateValidMovimentsForPlayer2(PlayerConfiguration playerConfiguration)
        {
            List<PlayerConfiguration> validMoviments = new List<PlayerConfiguration>();

            int pos1 = playerConfiguration.PositionPlayer1;
            int pos2 = playerConfiguration.PositionPlayer2;

            if (pos2 == 0) return validMoviments;
            if (pos2 == 1 && pos1 == 0) return validMoviments;

            if (pos2 == pos1 + 1)
            {
                validMoviments.Add(_playerConfigurationEnumeration.GetPlayerConfiguration(pos1, pos2 - 2));
                return validMoviments;
            }

            int limite;
            if (pos1 < pos2) limite = pos1;
            else limite = -1;

            for (int i = pos2 - 1; i >= limite + 1; i--)
            {
                validMoviments.Add(_playerConfigurationEnumeration.GetPlayerConfiguration(pos1, i));
            }
            return validMoviments;
        }

    }
}