namespace Pawns
{
    public class State
    {
        public int Player { get; set; }
        public BoardConfiguration Configuration { get; set; }


        public State(int player, BoardConfiguration configuration)
        {
            Player = player;
            Configuration = configuration;
        }
    }
}