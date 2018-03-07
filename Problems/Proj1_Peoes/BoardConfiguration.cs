using System;

namespace Proj1_Peoes
{
    public class BoardConfiguration
    {
        private Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration> configuration;

        public PlayerConfiguration Column1 => configuration.Item1;
        public PlayerConfiguration Column2=> configuration.Item2;
        public PlayerConfiguration Column3 => configuration.Item3;

        public bool IsTerminal { get; internal set; } //TODO: What is terminal?

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
