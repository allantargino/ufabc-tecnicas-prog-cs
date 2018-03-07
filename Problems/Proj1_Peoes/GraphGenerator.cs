using System;
using System.Collections.Generic;
using System.Text;

namespace Proj1_Peoes
{
    public class GraphGenerator
    {
        public ColumnValidMovimentsGenerator ColumnValidMovimentsGenerator { get; }
        public BoardColumnsGenerator BoardColumnsGenerator { get; }

        public GraphGenerator(ColumnValidMovimentsGenerator columnValidMovimentsGenerator, BoardColumnsGenerator boardColumnsGenerator)
        {
            ColumnValidMovimentsGenerator = columnValidMovimentsGenerator;
            BoardColumnsGenerator = boardColumnsGenerator;
        }

        public void GenerateValidMoviments()
        {
            for (int player = 1; player <= 2; player++)
            {
                for (int i = 1; i <= 8000; i++)
                {
                    var configuration = BoardColumnsGenerator.GetGameConfiguration(i);
                    var validMoviments = GenerateValidMovimentsForBoardConfiguration(player, configuration);

                    //Add
                }

            }

        }

        private IEnumerable<BoardConfiguration> GenerateValidMovimentsForBoardConfiguration(int player, BoardConfiguration boardConfiguration)
        {
            var validMoviments = new List<BoardConfiguration>();

            if (boardConfiguration.IsTerminal)
                return validMoviments;

            for (int i = 0; i <= 2; i++)
            {
                var k = new PlayerConfiguration[3];

                k[0] = boardConfiguration.Column1;
                k[1] = boardConfiguration.Column2;
                k[2] = boardConfiguration.Column3;


                var validMovimentsForK = ColumnValidMovimentsGenerator.GetValidMovimentsFor(player, k[i]);
                foreach (var moviment in validMovimentsForK)
                {
                    k[i] = moviment;
                    var validMoviment = BoardColumnsGenerator.GetGameConfiguration(k[0], k[1], k[2]);
                    validMoviments.Add(validMoviment);
                }
            }

            return validMoviments;
        }
    }
}
