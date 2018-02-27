using System;

namespace Proj1_Peoes
{
    partial class Program
    {
        public class BoardConfiguration
        {
            private Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration> configuration;

            public BoardConfiguration(PlayerConfiguration c1, PlayerConfiguration c2, PlayerConfiguration c3)
            {
                configuration = new Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>(c1, c2, c3);
            }

            public override string ToString()
            {
                return $"{configuration.Item1.ToString()}, {configuration.Item2.ToString()}, {configuration.Item3.ToString()}";
            }
        }


    }
}
