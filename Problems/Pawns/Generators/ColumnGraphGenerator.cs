﻿using System;
using System.Collections.Generic;

namespace Pawns
{
    public class ColumnValidMovimentsGenerator
    {
        private ColumnManager ColumnManager { get; }

        private IDictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>> ValidMovimentsPlayer1 { get; }
        private IDictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>> ValidMovimentsPlayer2 { get; }

        public ColumnValidMovimentsGenerator(ColumnManager columnGenerator)
        {
            ValidMovimentsPlayer1 = new Dictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>>();
            ValidMovimentsPlayer2 = new Dictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>>();

            ColumnManager = columnGenerator;
        }

        public void GenerateValidMoviments()
        {
            foreach (var playerConfiguration in ColumnManager.Configuration)
            {
                var moviment = playerConfiguration.Value;

                var validMoviments1 = GenerateValidMovimentsForPlayer1(moviment);
                ValidMovimentsPlayer1.Add(moviment, validMoviments1);

                var validMoviments2 = GenerateValidMovimentsForPlayer2(moviment);
                ValidMovimentsPlayer2.Add(moviment, validMoviments2);
            }
        }

        public IEnumerable<PlayerConfiguration> GetValidMovimentsFor(int player, PlayerConfiguration configuration)
        {
            if (player < 1 || player > 2) throw new ArgumentOutOfRangeException(nameof(player));

            if (player == 1)
                return ValidMovimentsPlayer1[configuration];

            if (player == 2)
                return ValidMovimentsPlayer2[configuration];

            throw new NotImplementedException();
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
                validMoviments.Add(ColumnManager.GetPlayerConfiguration(pos1 + 2, pos2));
                return validMoviments;
            }

            int limite;
            if (pos1 < pos2) limite = pos2;
            else limite = 5;

            for (int i = pos1 + 1; i <= limite - 1; i++)
            {
                validMoviments.Add(ColumnManager.GetPlayerConfiguration(i, pos2));
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
                validMoviments.Add(ColumnManager.GetPlayerConfiguration(pos1, pos2 - 2));
                return validMoviments;
            }

            int limite;
            if (pos1 < pos2) limite = pos1;
            else limite = -1;

            for (int i = pos2 - 1; i >= limite + 1; i--)
            {
                validMoviments.Add(ColumnManager.GetPlayerConfiguration(pos1, i));
            }
            return validMoviments;
        }

    }
}