﻿namespace Solver.Repository
{
    public sealed class ConnectionString
    {
        public ConnectionString(string value) => Value = value;
        public string Value { get; set; }
    }
}
