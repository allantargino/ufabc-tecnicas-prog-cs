﻿using System;
using System.Collections.Generic;

namespace Pawns
{
    public class GraphGenerator
    {
        private GraphValidMovimentsGenerator graphValidMovimentsGenerator;
        private IEnumerable<State> States;

        public GraphGenerator(GraphValidMovimentsGenerator graphValidMovimentsGenerator)
        {
            this.graphValidMovimentsGenerator = graphValidMovimentsGenerator;
        }

        public void GenerateGraph()
        {
            var graph = new Dictionary<State, IEnumerable<State>>();

            foreach (var state in States)
            {
                var validStates = new List<State>();

                foreach (var validMoviment in graphValidMovimentsGenerator.GetValidMoviments(state.Player, state.Configuration))
                    validStates.Add(new State(1 - state.Player, validMoviment));

                graph.Add(state, validStates);
            }
        }
    }
}