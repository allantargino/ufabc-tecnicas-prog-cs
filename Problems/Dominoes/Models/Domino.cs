using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Dominoes
{
    [DebuggerDisplay("({Value0}, {Value1})")]
    public class Domino
    {
        private (int, int) Value { get; }

        public int Value0 => Value.Item1;
        public int Value1 => Value.Item2;

        public Domino(int v0, int v1)
        {
            Value = (v0, v1);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 1) throw new IndexOutOfRangeException("Index allowed: 0 or 1");
                if (index == 0)
                    return Value0;
                return Value1;
            }
        }

        public Domino Rotate()
        {
            return new Domino(Value1, Value0);
        }
    }
}
