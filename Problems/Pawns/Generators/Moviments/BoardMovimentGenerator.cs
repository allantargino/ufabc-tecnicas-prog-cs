using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class BoardMovimentGenerator
    {
        private PlayerMovimentEnumeration _playerMovimentEnumeration { get; }
        private BoardConfigurationEnumeration _boardConfigurationEnumeration { get; }

        public BoardMovimentGenerator(PlayerMovimentEnumeration playerMovimentEnumeration, BoardConfigurationEnumeration boardConfigurationEnumeration)
        {
            _playerMovimentEnumeration = playerMovimentEnumeration;
            _boardConfigurationEnumeration = boardConfigurationEnumeration;
        }

        public BoardMovimentEnumeration Enumerate()
        {
            var validMovimentsPlayer1 = new Dictionary<BoardConfiguration, IEnumerable<BoardConfiguration>>();
            var validMovimentsPlayer2 = new Dictionary<BoardConfiguration, IEnumerable<BoardConfiguration>>();

            for (int player = 0; player <= 1; player++)
            {
                for (int i = 1; i <= 8000; i++)
                {
                    var configuration = _boardConfigurationEnumeration.GetGameConfiguration(i);
                    var validMoviments = GenerateValidMovimentsForBoardConfiguration(player, configuration);

                    //Save
                    if (player == 0)
                        validMovimentsPlayer1.Add(configuration, validMoviments);

                    if (player == 1)
                        validMovimentsPlayer2.Add(configuration, validMoviments);
                }
            }

            return new BoardMovimentEnumeration()
            {
                ValidMovimentsPlayer1 = validMovimentsPlayer1,
                ValidMovimentsPlayer2 = validMovimentsPlayer2
            };
        }

        private IEnumerable<BoardConfiguration> GenerateValidMovimentsForBoardConfiguration(int player, BoardConfiguration boardConfiguration)
        {
            var validMoviments = new List<BoardConfiguration>();

            if (boardConfiguration.IsTerminal(player))
                return validMoviments;

            for (int i = 0; i <= 2; i++)
            {
                var k = new PlayerConfiguration[3];

                k[0] = boardConfiguration.Column1;
                k[1] = boardConfiguration.Column2;
                k[2] = boardConfiguration.Column3;

                var validMovimentsForK = _playerMovimentEnumeration.GetValidMovimentsFor(player, k[i]);
                foreach (var moviment in validMovimentsForK)
                {
                    k[i] = moviment;
                    var validMoviment = _boardConfigurationEnumeration.GetGameConfiguration(k[0], k[1], k[2]);
                    validMoviments.Add(validMoviment);
                }
            }

            return validMoviments;
        }
    }
}
